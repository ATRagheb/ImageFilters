using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using System.Threading;
using ZGraphTools;
using System.Diagnostics;

namespace ImageFilters
{
    public partial class Alpha_form : Form
    {
        byte[,] ImageMatrix;
        byte[,] DisplayedImage;
        int filterSize;
        int trimValue;

        public Alpha_form(byte[,] image)
        {
            ImageMatrix = image;

            InitializeComponent();
        }

        private void Alpha_form_Load(object sender, EventArgs e)
        {
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);
        }

        private int kElements(int[] arr, int trimValue)       //O(tn^2)
        {
            int[] minValues = new int[trimValue];      //O(1)
            int[] maxValues = new int[trimValue];      //O(1)
            bool[] visited = new bool[arr.Length];     //O(1)


            int min = 100000;       //O(1)
            int max = 0;      //O(1)
            int index = 0;      //O(1)
            int sum = 0;      //O(1)
            int count = 0;      //O(1)

            for (int j = 0; j < minValues.Length; j++)      //O(tn^2)
            {
                for (int i = 0; i < arr.Length; i++)      //O(n^2)
                {

                    if (visited[i] == false)      //O(1)
                    {
                        if (arr[i] < min)      //O(1)
                        {
                            min = arr[i];      //O(1)
                            index = i;      //O(1)
                        }
                    }
                }

                visited[index] = true;       //O(1)
                minValues[j] = index;      //O(1)
                min = 10000;      //O(1)
            }

            Array.Clear(visited, 0, arr.Length);

            for (int j = 0; j < maxValues.Length; j++)      //O(tn^2)
            {
                for (int i = 0; i < arr.Length; i++)      //O(n^2)
                {

                    if (visited[i] == false)      //O(1)
                    {
                        if (arr[i] > max)      //O(1)
                        {
                            max = arr[i];      //O(1)
                            index = i;      //O(1)
                        }
                    }
                }

                visited[index] = true;      //O(1)
                maxValues[j] = index;      //O(1)
                max = 0;      //O(1)
            }

            bool x = true;      //O(1)

            for (int i = 0; i < arr.Length; i++)      //O(tn^2)
            {
                x = true;      //O(1)

                for (int j = 0; j < trimValue; j++)      //O(t)
                {
                    if (i == minValues[j] || i == maxValues[j])      //O(1)
                    {

                        x = false;      //O(1)
                        break;      //O(1)
                    }
                }

                if (x == true)          //O(1)
                {
                    count++;            //O(1)
                    sum += arr[i];      //O(1)
                }
            }

            int avg = sum / count;      //O(1)

            return avg;                  //O(1)
        }

        private int[] countingSort(int[] arr)       //O(k + n^2)
        {
            int size = arr.Length;      //O(1)
            int maxValue = -1000000;      //O(1)

            for (int i = 0; i < size; i++)      //O(n^2)
            {
                if (arr[i] > maxValue)      //O(1)
                {
                    maxValue = arr[i];      //O(1)
                }
            }

            int[] count = new int[maxValue + 1];      //O(1)

            for (int i = 0; i < size; i++)      //O(n^2)
            {
                count[arr[i]]++;      //O(1)
            }

            for (int i = 1; i <= maxValue; i++)      //O(k)  k: Max Number in OneDArray 
            {
                count[i] = count[i] + count[i - 1];      //O(1)
            }

            int[] sortedArr = new int[size];      //O(1)

            for (int i = size - 1; i >= 0; i--)      //O(n^2)
            {
                sortedArr[--count[arr[i]]] = arr[i];      //O(1)
            }

            return sortedArr;      //O(1)
        }

        private void Imageloop(int choice)        //O(h * w * t * n^2)
        {
            for (int i = (filterSize / 2); i < ImageMatrix.GetLength(0) - (filterSize / 2); i++)      //O(h * w * t * n^2)
            {
                for (int j = (filterSize / 2); j < ImageMatrix.GetLength(1) - (filterSize / 2); j++)      //O(w)
                {
                    ImageFilter(i, j, choice);      //O(tn^2)
                }
            }
        }


        private void ImageFilter(int height, int width, int choice)        //O(tn^2)
        {
            int[] oneDArray = new int[filterSize * filterSize];      //O(1)
            int index = 0;      //O(1)


            for (int i = height - (filterSize / 2); i <= height + (filterSize / 2); i++)      //O(n^2)
            {
                for (int j = width - (filterSize / 2); j <= width + (filterSize / 2); j++)      //O(n)
                {
                    oneDArray[index] = ImageMatrix[i, j];      //O(1)
                    index++;      //O(1)
                }
            }

            int x = 0;      //O(1)

            if (choice == 1)
            {
                oneDArray = countingSort(oneDArray);      //O(k + n^2)

                x = ChangePixelValue(oneDArray);        //O(n^2)
            }

            else if (choice == 2)
            {

                x = kElements(oneDArray, trimValue);        //O(t n^2)
            }

            DisplayedImage[height - (filterSize / 2), width - (filterSize / 2)] = (byte)x;        //O(1)
        }

        private int ChangePixelValue(int[] oneDArray)        //O(n^2)
        {
            int average;        //O(1)
            int sum = 0;        //O(1)
            int count = 0;        //O(1)

            for (int i = trimValue; i < (filterSize * filterSize) - trimValue; i++)        //O(n^2)
            {
                sum += oneDArray[i];        //O(1)
                count++;        //O(1)
            }

            average = sum / count;        //O(1)

            return average;        //O(1)
        }


        private void processButton_Click_1(object sender, EventArgs e)
        {

            filterSize = Decimal.ToInt32(filterSize_numericUpDown.Value);
            trimValue = Decimal.ToInt32(TrimValue_numericUpDown.Value);

            int newHeight = ImageMatrix.GetLength(0) - (filterSize - 1);
            int newWidth = ImageMatrix.GetLength(1) - (filterSize - 1);

            DisplayedImage = new byte[newHeight, newWidth];

            if (filterSize < 3)
            {
                MessageBox.Show("Filter Size Must be Greater Than or Equal 3");
                return;
            }
            if (filterSize % 2 == 0)
            {
                MessageBox.Show("Filter Size Must be an Odd Number");
                return;
            }

            int gridSize = filterSize * filterSize;
            int x = (gridSize - 1) / 2;

            if ((2 * trimValue) >= (gridSize))
            {
                MessageBox.Show("Trim Value Must Not Exceed: " + x);
                return;
            }


            Imageloop(1);               //O(h * w * t * n^2)
            ImageOperations.DisplayImage(DisplayedImage, pictureBox1);
        }

        private void graphButton_Click_1(object sender, EventArgs e)
        {
            int N = 4;
            double[] x_values = new double[N];
            double[] y_values_N = new double[N];
            double[] y_values_NT = new double[N];
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan ts;


            int yIndex = 0, xIndex = 0;

            if (object.Equals(DisplayedImage, null))
            {
                DisplayedImage = new byte[ImageMatrix.GetLength(0) - (filterSize - 1), ImageMatrix.GetLength(1) - (filterSize - 1)];
            }

            for (int j = 3; j <= 9; j += 2)
            {
                stopwatch.Reset();
                stopwatch.Start();
                filterSize = j;
                Imageloop(1);
                stopwatch.Stop();
                ts = stopwatch.Elapsed;

                y_values_N[yIndex++] = ts.TotalMilliseconds;

                x_values[xIndex++] = j;
            }

            yIndex = 0;

            for (int j = 3; j <= 9; j += 2)
            {
                stopwatch.Reset();
                stopwatch.Start();
                filterSize = j;
                Imageloop(2);
                stopwatch.Stop();
                ts = stopwatch.Elapsed;

                y_values_NT[yIndex++] = ts.TotalMilliseconds;
            }

            //Create a graph and add two curves to it
            ZGraphForm ZGF = new ZGraphForm("Sample Graph", "Window size", "Execution time");
            ZGF.add_curve("Counting sort", x_values, y_values_N, Color.Red); // Counting Sort
            ZGF.add_curve("KElements", x_values, y_values_NT, Color.Blue); // KElements Algorithm
            ZGF.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
            this.Close();
        }
    }
}
