namespace December2_1_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int safeReports = 0;
            bool isReportSafe = true;

            string filePath = "C:\\Users\\vah\\Desktop\\AdventOfCode\\December2(1)\\Dec2Input.txt";

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] reportValues = line.Split(' ');

                    int[] report = Array.ConvertAll(reportValues, s => int.Parse(s));

                    if (report[0] >= report[1])
                    {
                        for (int i = 0; i < report.Length - 1; i++)
                        {
                            if ((report[i] >= report[i + 1]) && (Math.Abs(report[i] - report[i + 1]) >= 1) && (Math.Abs(report[i] - report[i + 1]) <= 3))
                            {
                                continue;
                            }
                            else
                            {
                                isReportSafe = false;
                                break;
                            }
                        }

                        if (isReportSafe == true)
                        {
                            safeReports++;
                        }
                    }
                    else if (report[0] <= report[1])
                    {
                        for (int i = 0; i < report.Length - 1; i++)
                        {
                            if ((report[i] <= report[i + 1]) && (Math.Abs(report[i] - report[i + 1]) >= 1) && (Math.Abs(report[i] - report[i + 1]) <= 3))
                            {
                                continue;
                            }
                            else
                            {
                                isReportSafe = false;
                                break;
                            }
                        }

                        if (isReportSafe == true)
                        {
                            safeReports++;
                        }
                    }

                    isReportSafe = true;
                    line = null;
                }
            }

            Console.WriteLine(safeReports);
        }
    }
}
