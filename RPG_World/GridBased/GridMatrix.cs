using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RolePlayingGame.World.GridBased
{
    public class GridMatrix<T> where T : Grid
    {
        public GridMatrix()
        {
            matrix = new List<List<T>>();
        }

        private List<List<T>> matrix;
        protected List<List<T>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        public bool HasElement(T grid)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                if (grid.Y == matrix[row][0].Y)
                {
                    for (int column = 0; column < matrix[row].Count; column++)
                    {
                        if (grid.X == matrix[row][column].X)
                        {
                            return true;
                        }
                        else if (grid.X < matrix[row][column].X)
                        {
                            return false;
                        }
                    }
                }
                else if (grid.Y < matrix[row][0].Y)
                {
                    return false;
                }
            }
            return false;
        }

        public bool AddElement(T grid)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                if (grid.Y == matrix[row][0].Y)
                {
                    for (int column = 0; column < matrix[row].Count; column++)
                    {
                        if (grid.X == matrix[row][column].X)
                        {
                            return false;
                        }
                        else if (grid.X < matrix[row][column].X)
                        {
                            matrix[row].Insert(column, grid);
                            return true;
                        }
                    }
                    matrix[row].Add(grid);
                    return true;
                }
                else if (grid.Y < matrix[row][0].Y)
                {
                    List<T> rowListInsert = new List<T>();
                    rowListInsert.Add(grid);
                    matrix.Insert(row, rowListInsert);
                    return true;
                }
            }
            List<T> rowListAdd = new List<T>();
            rowListAdd.Add(grid);
            matrix.Add(rowListAdd);
            return true;
        }

        public bool RemoveElement(T grid)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                if (grid.Y == matrix[row][0].Y)
                {
                    for (int column = 0; column < matrix[row].Count; column++)
                    {
                        if (grid.X == matrix[row][column].X)
                        {
                            matrix[row].RemoveAt(column);
                            if (matrix[row].Count == 0)
                            {
                                matrix.RemoveAt(row);
                            }
                            return true;
                        }
                        else if (grid.X < matrix[row][column].X)
                        {
                            return false;
                        }
                    }
                }
                else if (grid.Y < matrix[row][0].Y)
                {
                    return false;
                }
            }
            return false;
        }

        public void Clear()
        {
            matrix.Clear();
        }

        /// <summary>
        /// Optimized GetArea method for very big arrays
        /// We only look to first and last elements of all rows 
        /// to calculate start.x & end.x factor of the area
        ///
        /// To Understand look at this grid list condition below:
        ///
        /// ///////////////////////////////////////
        /// //     /     /     /     /     /     //
        /// // (s) /     / G00 /     /     /     //
        /// //     /     /     /     /     /     //
        /// ///////////////////////////////////////
        /// //     /     /     /     /     /     //
        /// //     /     /     / G01 /     / G02 //
        /// //     /     /     /     /     /     //
        /// ///////////////////////////////////////
        /// //     /     /     /     /     /     //
        /// // G03 / G04 / G05 / G06 /     /     //
        /// //     /     /     /     /     /     //
        /// ///////////////////////////////////////
        /// //     /     /     /     /     /     //
        /// //     /     /     /     /     /     //
        /// //     /     /     /     /     /     //
        /// ///////////////////////////////////////
        /// //     /     /     /     /     /     //
        /// //     /     / G07 /     /     / (e) //
        /// //     /     /     /     /     /     //
        /// ///////////////////////////////////////
        /// 
        /// We need to find (s) & (e) but G00 & G07 are not 
        /// giving us any clue about X-direction but they
        /// But also look at yo G01, G04, G05 and G06 are 
        /// completely needless...
        /// </summary>
        /// <returns>Returns the area of matrix as a rectangle</returns>
        public GridArea GetArea()
        {
            if (matrix.Count == 0)
            {
                return null;
            }
            int rowCount = matrix.Count;
            int lastRowsColumnCount = matrix[rowCount - 1].Count;
            GridArea area = new GridArea(matrix[0][0], matrix[rowCount - 1][lastRowsColumnCount - 1]);
            for (int row = 0; row < matrix.Count; row++)
            {
                if (matrix[row][0].X < area.Start.X)
                {
                    area.Start.X = matrix[row][0].X;
                }
                int currRowsColumnCount = matrix[row].Count;
                if (matrix[row][currRowsColumnCount - 1].X > area.End.X)
                {
                    area.End.X = matrix[row][currRowsColumnCount - 1].X;
                }
            }
            return area;
        }

        public void Rotate(T axis, RotationTypes rotationType)
        {
            T[] array = ToArray();
            matrix.Clear();
            for (int index = 0; index < array.Length; index++)
            {
                Grid rotatedGrid = array[index].Rotate(axis, rotationType);
                array[index].X = rotatedGrid.X;
                array[index].Y = rotatedGrid.Y;
                AddElement(array[index]);
            }
        }

        [XmlIgnoreAttribute]
        public int RowCount
        {
            get { return matrix.Count; }
        }

        [XmlIgnoreAttribute]
        public int ElementCount
        {
            get
            {
                int count = 0;
                for (int index = 0; index < RowCount; index++)
                {
                    count += matrix[index].Count;
                }
                return count;
            }
        }

        public T[] ToArray()
        {
            List<T> array = new List<T>();
            for (int index = 0; index < RowCount; index++)
            {
                array.AddRange(matrix[index]);
            }
            return array.ToArray();
        }
    }
}
