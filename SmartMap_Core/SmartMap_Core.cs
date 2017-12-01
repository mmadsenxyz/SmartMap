/*
 * Code by Mark V Madsen
 * License BSD
*/
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.Xml;
using Axiom.Core;
using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.Search;
using QuickGraph.Algorithms.RandomWalks;
using QuickGraph.Collections;
using Wintellect.PowerCollections;

namespace SmartMap
{
    /// <summary>
    /// The algorithm calculation class
    /// </summary>
    public class SmartMap_Core
    {
        private SceneNode module;
        // Graph
        public BidirectionalGraph<Point<int>, Edge<Point<int>>> graph;
        public Point<int> pointGraph;
        public Point<int> pointSearch;
        public Point<int> pointFirst;
        public Point<int> pointLast;
        public Point<int> graphSize;
        public Edge<Point<int>> edge;
        public Edge<int> edge2;
        // Collections
        public MultiDictionary<Point<int>, Edge<Point<int>>> md;
        public MultiDictionary<Point<int>, Edge<Point<int>>> md2;
        public List<Vertex<float>> path_module;
        public List<List<Vertex<float>>> path_modules = new List<List<Vertex<float>>>();
        public IDictionary<Point<int>, int> vidSuccessors;
        public IDictionary<Point<int>, Edge<Point<int>>> vedSuccessors; 
        // Search     
        private BreadthFirstSearchAlgorithm<Point<int>, Edge<Point<int>>> bfs;
        //private DepthFirstSearchAlgorithm<Point<int>, Edge<Point<int>>> dfs;
        //private ConnectedComponentsAlgorithm<Point<int>, Edge<Point<int>>> cca;
        private CyclePoppingRandomTreeAlgorithm<Point<int>, Edge<Point<int>>> pop;
         // Save

        #region Properties

        // Graph Verteces 
        public int Length
        {
            get { return this.graphSize.Length; }
            set { this.graphSize.Length = value; }
        }
        public int Width
        {
            get { return this.graphSize.Width; }
            set { this.graphSize.Width = value; }
        }
		
        #endregion

        #region Graph

        /// <summary>
        /// Create a new genreic graph and multi-dictionary for structure or object
        /// </summary>
        /// <param name="staggered">Stagger graph for oblong structures</param>
        public void GenerateGraph(string type, bool staggered, int width, int length)
        {
            // Create Graph
            this.graphSize = new Point<int>(width, length);
     
            // stagger later          
            Random rnd = new Random();
            int stagger = rnd.Next(0, (int)Width);

            // create a new graph			
            this.graph = new BidirectionalGraph<Point<int>, Edge<Point<int>>>(false);

            // adding vertices		    
            for (int i = 0; i < Width; ++i)
            {
                for (int j = 0; j < Length; ++j)
                {
                    if (staggered) {
                        if (stagger == Width / 2) // stagger the graph for oblong structures
                            continue;
                    }
                    pointGraph = new Point<int>(i, j);
                    this.graph.AddVertex(pointGraph);
                }
            }
                    
            // adding Width edges			    
            for (int i = 0; i < Width; ++i)
            {
                for (int j = 0; j < Length - 1; ++j)
                {
                    this.edge = new Edge<Point<int>>(new Point<int>(i, j), new Point<int>(i, j + 1));
                    this.graph.AddEdge(edge);
                } 
            }

            // adding Length edges			    
            for (int j = 0; j < Length; ++j)
            {
                for (int i = 0; i < Width - 1; ++i)
                {
                    this.edge = new Edge<Point<int>>(new Point<int>(i, j), new Point<int>(i + 1, j));
                    this.graph.AddEdge(edge);
                } 
            }
            
            if (type == "TILESET")
            { 
                // initialize MultiDictionary for easier tileset creation   
                this.md = new MultiDictionary<Point<int>, Edge<Point<int>>>(true);
                foreach (Edge<Point<int>> e in this.graph.Edges)
                {      
                    this.md.Add(e.Source, e); // out-edge
                    this.md.Add(e.Target, e); // in-edge
                        //Console.WriteLine("The vertices are: {0} {1}", e.Source, e);
                }
            }
            
            if (type == "MAP")
            {
                // initialize MultiDictionary 2 for easier map creation   
                this.md2 = new MultiDictionary<Point<int>, Edge<Point<int>>>(true);
                foreach (Edge<Point<int>> e in this.graph.Edges)
                {      
                    this.md2.Add(e.Source, e); // out-edge
                    this.md2.Add(e.Target, e); // in-edge
                        //Console.WriteLine("The vertices are: {0} {1}", e.Source, e);
                }
            }
        }
       
        /// <summary>
        /// Non-adjacent (not connected) but nearby vertices checked for empty edges
        /// </summary>
        /// <param name="v">Initial edged vertex</param>
        /// <returns></returns>
        public string NearbyVerticesEmpty(Point<int> v)
        {
            if ((!this.graph.ContainsVertex(new Point<int>(v.Width + 1, v.Length - 1)))
                 & (!this.graph.ContainsVertex(new Point<int>(v.Width + 1, v.Length)))
                 & (!this.graph.ContainsVertex(new Point<int>(v.Width, v.Length - 1))))
                {
                    return "empty_corner"; // NE
                }

            if ((!this.graph.ContainsVertex(new Point<int>(v.Width - 1, v.Length - 1)))
                 & (!this.graph.ContainsVertex(new Point<int>(v.Width - 1, v.Length)))
                 & (!this.graph.ContainsVertex(new Point<int>(v.Width, v.Length - 1))))
                {
                    return "empty_corner"; // NW
                }

            if ((!this.graph.ContainsVertex(new Point<int>(v.Width + 1, v.Length + 1)))
                 & (!this.graph.ContainsVertex(new Point<int>(v.Width + 1, v.Length)))
                 & (!this.graph.ContainsVertex(new Point<int>(v.Width, v.Length + 1))))
                {
                    return "empty_corner"; // SE
                }

            if ((!this.graph.ContainsVertex(new Point<int>(v.Width - 1, v.Length + 1)))
                 & (!this.graph.ContainsVertex(new Point<int>(v.Width - 1, v.Length)))
                 & (!this.graph.ContainsVertex(new Point<int>(v.Width, v.Length + 1))))
                {
                    return "empty_corner"; // SW
                }
          
            return "not_empty";
        }
        
        #endregion

        #region Search
        
        /// <summary>
        /// Intelligent Path Generator 
        /// </summary>
        /// <param name="rootX">Root x: Must be less than tileAmount</param>
        /// <param name="rootZ">Root z: Must be less than tileAmount</param>
        public bool GeneratePath(string type, bool automated, int branchX, int branchZ, int rootX, int rootZ)
        {
            this.vedSuccessors = new Dictionary<Point<int>, Edge<Point<int>>>();
                            
            // create cross edges for better maze making 
            foreach (Edge<Point<int>> e in this.graph.Edges) {  
                this.edge = new Edge<Point<int>>(e.Target, e.Source);
                this.graph.AddEdge(edge);
             }
             
             if (automated) {
                // find a branch(entrance) and root(exit) that exists on the borders
                int tick = 0;
                foreach (Point<int> v in this.graph.Vertices) {   
                    if (this.graph.ContainsVertex(v) & this.graph.Degree(v) > 0) { // if it has edges
                        if (tick == 0) {  
                            branchX = v.Width;
                            branchZ = v.Length;
                            tick++;  
                        }
                        rootX = v.Width;
                        rootZ = v.Length;
                            // Console.WriteLine("{0}", v.ToString());
                    } else {
                        return false;
                    }
                }
            }
            // fill in the entrance vertex for searcher
            pointFirst.Width = branchX;
            pointFirst.Length = branchZ;
            
             // weight the out-edges
            Dictionary<Edge<Point<int>>, double> weights = new Dictionary<Edge<Point<int>>, double>();
            foreach (Edge<Point<int>> e in this.graph.Edges) {
                weights[e] = 4;
            }
            
            // maze with path from the uniform graph            
            this.pop = new CyclePoppingRandomTreeAlgorithm<Point<int>, Edge<Point<int>>>
                (this.graph);//, new WeightedMarkovEdgeChain<Point<int>, Edge<Point<int>>>(weights));
                
            this.pop.StateChanged += new EventHandler(this.StateStatus);
          
            try { // create a Random Tree Maze with exit root. Creates new edges for you.
                pop.RandomTreeWithRootBranch(new Point<int>(branchX, branchZ), new Point<int>(rootX, rootZ));           
            }
            catch (Exception ex) {
                    Console.WriteLine("{0} Module couldn't be searched... SKIPPING", ex.ToString());
                return false;    
            }
                Console.WriteLine("--------SEARCHING MODULE PATH-------");
                Console.WriteLine("Vertex: {0}:{1} is the exit for this module", 9, 1);
            this.vedSuccessors = pop.Successors;
        
            // delete all edges before edge re-population 
            foreach (Point<int> v in this.graph.Vertices) {
                   this.graph.ClearEdges(v);
            }

             if (type == "TILESET")
            {
                // put graph in MultiDictionary for map creation (populate edges) 
                foreach (Edge<Point<int>> e in this.vedSuccessors.Values)
                {
                    if (e == null)   // if empty, skip and continue the edge search
                        continue;
                        //Console.WriteLine("{0} was successfull.", e.ID); 
                    // grab these mazed vertex/edges for vertex/edge print-out in CreateTileset()
                    this.md.Add(e.Source, e); // out-edge
                    this.md.Add(e.Target, e); // in-edge
                        //Console.WriteLine("Edge {0}", e.Target, e.Source);
                    // redo the cleared graph with new random edges
                    this.graph.AddEdge(e);
                }
            }
            
            if (type == "MAP")
            {
                // put graph in MultiDictionary for map creation (populate edges) 
                foreach (Edge<Point<int>> e in this.vedSuccessors.Values)
                {
                    if (e == null)   // if empty, skip and continue the edge search
                        continue;
                        //Console.WriteLine("{0} was successfull.", e.ID); 
                    // grab these mazed vertex/edges for vertex/edge print-out in CreateTileset()
                    this.md2.Add(e.Source, e); // out-edge
                    this.md2.Add(e.Target, e); // in-edge
                        //Console.WriteLine("Edge {0}", e.Target, e.Source);
                    // redo the cleared graph with new random edges
                    this.graph.AddEdge(e);
                }
            }
            
            // remove edgeless vertices 
            for (int x = 0; x < this.Width; x++) 
                for (int z = 0; z < this.Length; z++) 
                    if (this.graph.ContainsVertex(new Point<int>(x, z)))
                        if (this.graph.Degree(new Point<int>(x, z)) == 0)
                            this.graph.RemoveVertex(new Point<int>(x, z));
                   
            // GC.Collect(); // could probably be used. Not too slow.
                        
            return true;
        }

        /// <summary>
        /// Search and sort intelligently created graph for path-finding 
        /// </summary>
        /// <param name="searchType">Choose BFS, DFS, COMPONENT, or NONE</param>
        /// <param name="module">Module to search</param>
        public void SearchPath(string searchType, SceneNode mod)
        {
            this.module = mod;
            
            this.path_module = new List<Vertex<float>>(); // create a new List and add it to path_modules
        
            // BreadthFirstSearch Search - Shortest path 
            if (searchType == "BFS")
            {
                this.bfs = new BreadthFirstSearchAlgorithm<Point<int>, Edge<Point<int>>>(this.graph);
                
                //this.bfs.StartVertex += new VertexAction<Point<int>>(this.RecordStartVertex);
                this.bfs.ExamineVertex += new VertexAction<Point<int>>(this.RecordVertex);
                
                try { 
                    this.bfs.Compute(pointFirst);
                }
                catch (Exception ex) {
                        Console.WriteLine("{0} Can't find entrance...Module can't be pathed", ex.ToString());
                }
                    //Console.WriteLine("Vertex: {0} is the entrence for this module", this.pointFirst);
                    Console.WriteLine("Point: {0} is the entrance for this module", new Point<int>(1, 1));
                    Console.WriteLine("Module solution path is:");
                  
                // add to multi-dictiionary to store all module paths                
                this.path_modules.Add(path_module);         
                                  
                foreach (List<Vertex<float>> list in this.path_modules) {
                    foreach (Vertex<float> v in list) {
                        Console.WriteLine("{0} vertex", v.ToString());
                    }
                }  
            }
            
            // DepthFirstSearch Search - Searches all verteces and orders them
            if (searchType == "DFS")
            {/*
                // DFS Search
                this.dfs = new DepthFirstSearchAlgorithm<Point<int>, Edge<Point<int>>>(this.graph);
                
                //this.dfs.ExamineEdge += new EdgeAction<Point<int>, Edge<Point<int>>>(this.RecordOutEdge);
                this.dfs.StartVertex += new VertexAction<Point<int>>(this.RecordStartVertex);
                this.bfs.ExamineVertex += new VertexAction<Point<int>>(this.RecordVertex);
                //this.dfs.Finished += new VertexAction<Point<int>>(this.RecordLastVertex);
                
                // start the search
                this.dfs.Compute(new Point<int>(2, 0, 2));  
                    Console.WriteLine("Verteces: {0} is the entrence for this module", this.pointFirst);*/
            }

            // ConnectedComponents search
            if (searchType == "COMPONENT")
            {/*
                this.cca = new ConnectedComponentsAlgorithm<Point<int>, Edge<Point<int>>>(this.graph);
                this.cca.Compute();
                this.vidSuccessors = this.cca.Components;

                // output Component listing to Console
                foreach (int a in this.vidSuccessors.Values)
                {
                    Console.WriteLine("{0}", a);
                }
                Console.ReadLine();

                Console.WriteLine("{0}", this.cca.ComponentCount);
                Console.ReadLine();*/
            }
        }
        
        private void StateStatus(object obj, EventArgs ea)
        {
            Console.WriteLine("Maze creator: {0}", pop.State.ToString());         
        }
        
        ///<summary>
        /// DFS Search Algorithm: Record vertexes
        ///</summary>
        private void RecordVertex(Point<int> point)
        { // all module nodes are same height
            Vertex<float> vertex = new Vertex<float>();
            vertex.Width = module.Position.x + (point.Width *  Draw3D.MeshSize); 
            vertex.Length = module.Position.z + (point.Length * Draw3D.MeshSize);
            vertex.Height = module.Position.y;
            this.path_module.Add(vertex);           
        }
        
        // don't  this for now
        private void RecordStartVertex(Point<int> point)
        {
            this.pointFirst = point;
        }

        private void RecordLastVertex(object sender, VertexEventArgs<Point<int>> args)
        {
            this.pointLast = args.Vertex;
        }
        
        ///<summary>
        /// DFS Search Algorithm: Record vertexes
        ///</summary>
        private void FinishVertex(Point<int> point)
        {
            this.pointSearch = point;
                //Console.WriteLine("{0} is the first vertex with an out-edge", this.vertex);
        }

        ///<summary>
        /// DFS Search Algorithm: Record outedges
        ///</summary>
        private void RecordOutEdge(Edge<Point<int>> args)
        {
                Console.WriteLine("{0} is the first vertex with an out-edge", args.Source);
            this.pointSearch = args.Source;
            //this.dfs.ExamineEdge -= new EdgeAction<Point<int>, Edge<Point<int>>>(this.RecordOutEdge);

            //this.vesdSuccessors[vertex].Add(args.Edge);
            //this.ec.Add(args.Edge);
            //vertex (from RecordVertex) and its' cooresponding out-edge
            //this.vesdSuccessors.Add(this.vertex, ec);
        }

        /// <summary>
        /// Store edge dictionaries for future reference
        /// </summary>
        public void Save()
        {
            //this.storeVed[vedCount] = ved;
            //vedCount++;
            try
            {
                // Creates an XML file is not exist
                XmlTextWriter XMLWriter = new XmlTextWriter(@"E:\Visual Studio\PROJECTS\SmartMap\bin\Debug\Sectors.xml", null);

                // Allow for indenting to make the xml file readable.
                XMLWriter.Formatting = Formatting.Indented;
                //
                // Add comments if necessary.
                XMLWriter.WriteComment("Name and address XML file");

                // Write an element (this one is the root)
                XMLWriter.WriteStartElement("AddressBook");

                // Add the employee element.
                XMLWriter.WriteStartElement("Employee");

                // Add the data for each employee here.
                XMLWriter.WriteStartElement("FirstName");
                XMLWriter.WriteString("Person1");
                XMLWriter.WriteEndElement();
                //XMLWriter.WriteEndAttribute();     

                //Write the title
                XMLWriter.WriteStartElement("LastName");
                XMLWriter.WriteString("Car2");
                XMLWriter.WriteEndElement();

                // Write the end tag for the employee element
                XMLWriter.WriteEndElement();

                // Write the close tag for the root element
                XMLWriter.WriteEndElement();

                //Write the XML to file and close the writer
                XMLWriter.Flush();
                XMLWriter.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
            }
            finally
            {
                //XMLWriter = null;
            }
        }

        public void Load()
        {
        }

        #endregion

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try {
                using (Draw3D d3d = new Draw3D()) {
                    d3d.Run();
                }
            }
            catch (Exception ex) {
                Debug.Assert(false, ex.ToString(), Environment.StackTrace.ToString());
            }
        }
    }

    #region STRUCTS 

    /// <summary>
    /// Point struct 
    /// </summary>
    public struct Point<T> : IEquatable<Point<T>>  //IComparable // for ordered dictionary
    {
        private T width;
        private T length;
   
        public Point(T width, T length)
        { 
            this.width = width; 
            this.length = length;      
        }

        public T Width { get { return this.width; } set { this.width = value; } }
 
        public T Length { get { return this.length; } set {this.length = value;} }
        
        /// <summary>
        /// Use Equals method to allow true for different objects to compare.
        /// Otherwise it is false and wont work
        /// </summary>
        /// <param name="other">Vertex</param>
        /// <returns></returns>
        public bool Equals(Point<T> other)
        {
            bool result = false;

            if (this.length.Equals(other.Length) && this.width.Equals(other.Width))
            {
                result = true;
            }
            return result;
        }
               
        /*
        int IComparable.CompareTo(object obj)
        {         
            Point<int> v = (Point<int>) obj;
           
            if (this.Length > v.Length)
            return(1);
            if (this.Width < v.Width)
            return(-1);
            else
            return(0);
        }
        */
        public override string ToString()
        {
            return(String.Format("{0} : {1}", Width, Length));
        }
    }

    /// <summary>
    /// Vertex struct 
    /// </summary>
    public struct Vertex<T> : IEquatable<Vertex<T>>  //IComparable // for ordered dictionary
    {
        private T width;
        private T height;
        private T length;
   
        public Vertex(T width, T height, T length)
        { 
            this.width = width; 
            this.height = height;        
            this.length = length;      
        }

        public T Width { get { return this.width; } set { this.width = value; } }

        public T Height { get { return this.height; } set { this.height = value; } }
 
        public T Length { get { return this.length; } set {this.length = value;} }
        
        /// <summary>
        /// Use Equals method to allow true for different objects to compare.
        /// Otherwise it is false and wont work
        /// </summary>
        /// <param name="other">Vertex</param>
        /// <returns></returns>
        public bool Equals(Vertex<T> other)
        {
            bool result = false;

            if (this.length.Equals(other.Length) && this.width.Equals(other.Width) && this.height.Equals(other.Height))
            {
                result = true;
            }
            return result;
        }
               
        /*
        int IComparable.CompareTo(object obj)
        {         
            Vertex<float> v = (Vertex<float>) obj;
           
            if (this.Length > v.Length)
            return(1);
            if (this.Width < v.Width)
            return(-1);
            else
            return(0);
        }
        */
        public override string ToString()
        {
            return(String.Format("{0} : {1} : {2}", Width, Height, Length));
        }
    }
    
    #endregion
}