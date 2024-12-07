namespace December2_2_
{
    internal class Program
    {
        static bool IsArrayIncreasing(int[] arr, ref int breakingIndex)
        {
            bool isIncreasing = false;
            int increasing = 0, decreasing = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] >= arr[i + 1])
                {
                    decreasing++;
                }
                else
                {
                    increasing++;
                }
            }

            if(increasing > decreasing)
            {
                isIncreasing = true;
                
                if(decreasing == 1)
                {
                    for(int i = 0; i < arr.Length - 1; i++)
                    {
                        if (arr[i] >= arr[i + 1])
                        {
                            breakingIndex = i + 1; 
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            else
            {
                isIncreasing = false;

                if (increasing == 1)
                {
                    for (int i = 0; i < arr.Length - 1; i++)
                    {
                        if (arr[i] <= arr[i + 1])
                        {
                            breakingIndex = i;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }

            return isIncreasing;
        }

        static void Main(string[] args)
        {
            int safeReports = 0, breakingIndex = int.MaxValue;
            bool isReportSafe = true, isSingleLevelRemoved = false;

            string filePath = "C:\\Users\\vah\\Desktop\\AdventOfCode\\December2(1)\\Dec2Input.txt";

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] reportValues = line.Split(' ');

                    int[] report = Array.ConvertAll(reportValues, s => int.Parse(s));

                    if (!IsArrayIncreasing(report, ref breakingIndex))
                    {
                        if (breakingIndex != int.MaxValue)
                        {
                            for (int i = 0; i < report.Length - 1; i++)
                            {
                                if (report[i] >= report[i + 1])
                                {
                                    if ((Math.Abs(report[i] - report[i + 1]) >= 1) && (Math.Abs(report[i] - report[i + 1]) <= 3))
                                    {
                                        continue;
                                    }
                                    else if (i == 0 && Math.Abs(report[i] - report[i + 1]) > 3)
                                    {
                                        if ((report[i + 1] >= report[i + 2]) && (isSingleLevelRemoved == false) && (Math.Abs(report[i + 1] - report[i + 2]) >= 1) && (Math.Abs(report[i + 1] - report[i + 2]) <= 3))
                                        {
                                            isSingleLevelRemoved = true;
                                            continue;
                                        }
                                        else
                                        {
                                            isReportSafe = false;
                                            break;
                                        }
                                    }
                                    else if ((Math.Abs(report[i] - report[i + 1]) > 3) || (Math.Abs(report[i] - report[i + 1]) < 1))
                                    {
                                        if ((report[i - 1] >= report[i + 1]) && (isSingleLevelRemoved == false) && (Math.Abs(report[i - 1] - report[i + 1]) >= 1) && (Math.Abs(report[i - 1] - report[i + 1]) <= 3))
                                        {
                                            isSingleLevelRemoved = true;
                                            continue;
                                        }
                                        else
                                        {
                                            isReportSafe = false;
                                            break;
                                        }
                                    }

                                    else if ((report[i] >= report[i + 2]) && (isSingleLevelRemoved == false) && (Math.Abs(report[i] - report[i + 2]) >= 1) && (Math.Abs(report[i] - report[i + 2]) <= 3))
                                    {
                                        isSingleLevelRemoved = true;
                                        continue;
                                    }
                                    else if (i == report.Length - 2)
                                    {
                                        if ((report[i - 1] >= report[i + 1]) && (isSingleLevelRemoved == false) && (Math.Abs(report[i - 1] - report[i + 1]) >= 1) && (Math.Abs(report[i - 1] - report[i + 1]) <= 3))
                                        {
                                            isSingleLevelRemoved = true;
                                            continue;
                                        }
                                        else
                                        {
                                            isReportSafe = false;
                                            break;
                                        }
                                    }
                                }
                                else if (i == report.Length - 2)
                                {
                                    if ((report[i - 1] >= report[i + 1]) && (isSingleLevelRemoved == false) && (Math.Abs(report[i - 1] - report[i + 1]) >= 1) && (Math.Abs(report[i - 1] - report[i + 1]) <= 3))
                                    {
                                        isSingleLevelRemoved = true;
                                        continue;
                                    }
                                    else
                                    {
                                        isReportSafe = false;
                                        break;
                                    }
                                }
                                else if (report[i] <= report[i + 2])
                                {
                                    if ((Math.Abs(report[i] - report[i + 2]) >= 1) && (Math.Abs(report[i] - report[i + 2]) <= 3))
                                    {
                                        i++;
                                        isSingleLevelRemoved = true;
                                        continue;
                                    }
                                    else
                                    {
                                        isReportSafe = false;
                                        break;
                                    }
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
                        else
                        {
                            for (int i = 0; i < report.Length - 1; i++)
                            {
                                if (report[i] >= report[i + 1])
                                {
                                    if ((Math.Abs(report[i] - report[i + 1]) >= 1) && (Math.Abs(report[i] - report[i + 1]) <= 3))
                                    {
                                        continue;
                                    }
                                    else if (i == 0 && Math.Abs(report[i] - report[i + 1]) > 3)
                                    {
                                        if ((report[i + 1] >= report[i + 2]) && (isSingleLevelRemoved == false) && (Math.Abs(report[i + 1] - report[i + 2]) >= 1) && (Math.Abs(report[i + 1] - report[i + 2]) <= 3))
                                        {
                                            isSingleLevelRemoved = true;
                                            continue;
                                        }
                                        else
                                        {
                                            isReportSafe = false;
                                            break;
                                        }
                                    }
                                    else if ((report[i] >= report[i + 2]) && (isSingleLevelRemoved == false) && (Math.Abs(report[i] - report[i + 2]) >= 1) && (Math.Abs(report[i] - report[i + 2]) <= 3))
                                    {
                                        isSingleLevelRemoved = true;
                                        continue;
                                    }
                                    else if (i == report.Length - 2)
                                    {
                                        if ((report[i - 1] >= report[i + 1]) && (isSingleLevelRemoved == false) && (Math.Abs(report[i - 1] - report[i + 1]) >= 1) && (Math.Abs(report[i - 1] - report[i + 1]) <= 3))
                                        {
                                            isSingleLevelRemoved = true;
                                            continue;
                                        }
                                        else
                                        {
                                            isReportSafe = false;
                                            break;
                                        }
                                    }
                                }
                                else if (i == report.Length - 1)
                                {
                                    if ((report[i - 1] >= report[i + 1]) && (isSingleLevelRemoved == false) && (Math.Abs(report[i - 1] - report[i + 1]) >= 1) && (Math.Abs(report[i - 1] - report[i + 1]) <= 3))
                                    {
                                        isSingleLevelRemoved = true;
                                        continue;
                                    }
                                    else
                                    {
                                        isReportSafe = false;
                                        break;
                                    }
                                }
                                else if (report[i] >= report[i + 2])
                                {
                                    if ((Math.Abs(report[i] - report[i + 2]) >= 1) && (Math.Abs(report[i] - report[i + 2]) <= 3))
                                    {
                                        i++;
                                        isSingleLevelRemoved = true;
                                        continue;
                                    }
                                    else
                                    {
                                        isReportSafe = false;
                                        break;
                                    }
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
                    }
                    else
                    {
                        if(breakingIndex != int.MaxValue)
                        {
                            for (int i = 0; i < report.Length - 1; i++)
                            {
                                if (report[i] <= report[i + 1])
                                {
                                    if((Math.Abs(report[i] - report[i + 1]) >= 1) && (Math.Abs(report[i] - report[i + 1]) <= 3))
                                    {
                                        continue;
                                    }
                                    else if (i == 0 && Math.Abs(report[i] - report[i + 1]) > 3)
                                    {
                                        if ((report[i + 1] <= report[i + 2]) && (isSingleLevelRemoved == false) && (Math.Abs(report[i + 1] - report[i + 2]) >= 1) && (Math.Abs(report[i + 1] - report[i + 2]) <= 3))
                                        {
                                            isSingleLevelRemoved = true;
                                            continue;
                                        }
                                        else
                                        {
                                            isReportSafe = false;
                                            break;
                                        }
                                    }
                                    else if ((Math.Abs(report[i] - report[i + 1]) > 3) || (Math.Abs(report[i] - report[i + 1]) < 1))
                                    {
                                        if((report[i - 1] <= report[i + 1]) && (isSingleLevelRemoved == false) && (Math.Abs(report[i - 1] - report[i + 1]) >= 1) && (Math.Abs(report[i - 1] - report[i + 1]) <= 3))
                                        {
                                            isSingleLevelRemoved = true;
                                            continue;
                                        }
                                        else
                                        {
                                            isReportSafe = false;
                                            break;
                                        }
                                    }
                                    else if ((report[i] <= report[i + 2]) && (isSingleLevelRemoved == false) && (Math.Abs(report[i] - report[i + 2]) >= 1) && (Math.Abs(report[i] - report[i + 2]) <= 3))
                                    {
                                        isSingleLevelRemoved = true;
                                        continue;
                                    }
                                    else if (i == report.Length - 2)
                                    {
                                        if ((report[i - 1] <= report[i + 1]) && (isSingleLevelRemoved == false) && (Math.Abs(report[i - 1] - report[i + 1]) >= 1) && (Math.Abs(report[i - 1] - report[i + 1]) <= 3))
                                        {
                                            isSingleLevelRemoved = true;
                                            continue;
                                        }
                                        else
                                        {
                                            isReportSafe = false;
                                            break;
                                        }
                                    }
                                }
                                else if(i == report.Length - 2)
                                {
                                    if ((report[i - 1] <= report[i + 1]) && (isSingleLevelRemoved == false) && (Math.Abs(report[i - 1] - report[i + 1]) >= 1) && (Math.Abs(report[i - 1] - report[i + 1]) <= 3))
                                    {
                                        isSingleLevelRemoved = true;
                                        continue;
                                    }
                                    else
                                    {
                                        isReportSafe = false;
                                        break;
                                    }
                                }
                                else if (report[i] <= report[i + 2]){
                                    if ((Math.Abs(report[i] - report[i + 2]) >= 1) && (Math.Abs(report[i] - report[i + 2]) <= 3))
                                    {
                                        i++;
                                        isSingleLevelRemoved = true;
                                        continue;
                                    }
                                    else
                                    {
                                        isReportSafe = false;
                                        break;
                                    }
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
                        else
                        {
                            for (int i = 0; i < report.Length - 1; i++)
                            {
                                if (report[i] <= report[i + 1])
                                {
                                    if ((Math.Abs(report[i] - report[i + 1]) >= 1) && (Math.Abs(report[i] - report[i + 1]) <= 3))
                                    {
                                        continue;
                                    }
                                    else if (i == 0 && Math.Abs(report[i] - report[i + 1]) > 3)
                                    {
                                        if ((report[i + 1] <= report[i + 2]) && (isSingleLevelRemoved == false) && (Math.Abs(report[i + 1] - report[i + 2]) >= 1) && (Math.Abs(report[i + 1] - report[i + 2]) <= 3))
                                        {
                                            isSingleLevelRemoved = true;
                                            continue;
                                        }
                                        else
                                        {
                                            isReportSafe = false;
                                            break;
                                        }
                                    }
                                    else if ((report[i] <= report[i + 2]) && (isSingleLevelRemoved == false) && (Math.Abs(report[i] - report[i + 2]) >= 1) && (Math.Abs(report[i] - report[i + 2]) <= 3))
                                    {
                                        isSingleLevelRemoved = true;
                                        continue;
                                    }
                                    else
                                    {
                                        isReportSafe = false;
                                        break;
                                    }
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
                    }

                    isSingleLevelRemoved = false;
                    isReportSafe = true;
                    line = null;
                }
            }

            Console.WriteLine(safeReports);
        }
    }
}
