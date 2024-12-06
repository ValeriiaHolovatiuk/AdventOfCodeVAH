namespace December1_1_
{
    internal class Program
    {

        static void bubbleSort(int[] arr, int n)
        {
            int i, j, temp;
            bool swapped;
            for (i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (swapped == false)
                    break;
            }
        }

        static int getTheDistance(int[] leftArr, int[] rightArr) 
        {
            int tempDistance, totalDistance = 0;

            bubbleSort(leftArr, leftArr.Length);
            bubbleSort(rightArr, rightArr.Length);

            for (int i = 0; i < leftArr.Length; i++)
            {
                if ((leftArr[i] - rightArr[i]) < 0)
                {
                    tempDistance = leftArr[i] - rightArr[i];
                    tempDistance = Math.Abs(tempDistance);
                }
                else
                {
                    tempDistance = leftArr[i] - rightArr[i];
                }

                totalDistance += tempDistance;
            }

            return totalDistance;
        }

        static void getTheValuesFromFile(string fileName, int[] arr)
        {
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);

                for (int i = 0; i < lines.Length; i++)
                {
                    arr[i] = int.Parse(lines[i]);
                }
            }
        }

        static void Main(string[] args)
        {
            int[] leftList = new int[1000];
            int[] rightList = new int[1000];

            getTheValuesFromFile("C:\\Users\\vah\\Desktop\\AdventOfCode\\December1(1)\\leftList.txt", leftList);
            getTheValuesFromFile("C:\\Users\\vah\\Desktop\\AdventOfCode\\December1(1)\\rightList.txt", rightList);

            Console.WriteLine(getTheDistance(leftList, rightList));

            Thread.Sleep(1000);
            Console.ReadLine();

            Environment.Exit(0);
        }
    }
}
