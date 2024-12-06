namespace December1_2_
{
    internal class Program
    {
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

        static int getSimilarityScore(int[] arrLeft, int[] arrRight)
        {
            int appearenceTime = 0, similarityScore = 0;

            for (int i = 0; i < arrRight.Length; i++)
            {
                for (int j = 0; j < arrLeft.Length; j++)
                {
                    if (arrLeft[i] == arrRight[j])
                    {
                        appearenceTime++;
                    }
                }

                similarityScore += arrLeft[i] * appearenceTime;

                appearenceTime = 0;
            }

            return similarityScore;
        }

        static void Main(string[] args)
        {
            int[] leftList = new int[1000];
            int[] rightList = new int[1000];

            getTheValuesFromFile("C:\\Users\\vah\\Desktop\\AdventOfCode\\December1(1)\\leftList.txt", leftList);
            getTheValuesFromFile("C:\\Users\\vah\\Desktop\\AdventOfCode\\December1(1)\\rightList.txt", rightList);

            int appearenceTime = 0, similarityScore = 0;

            for (int i = 0; i < rightList.Length; i++)
            {
                for (int j = 0; j < leftList.Length; j++)
                {
                    if (leftList[i] == rightList[j])
                    {
                        appearenceTime++;
                    }
                }

                similarityScore += leftList[i] * appearenceTime;

                appearenceTime = 0;
            }

            Console.WriteLine(getSimilarityScore(leftList, rightList));
        }
    }
}
