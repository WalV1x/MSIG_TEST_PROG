
//Auteur      : Liandro Gameiro
//Date        : 08.02.2024
//Description : Permet d'importer des données dans une base de donnée avec des conditions.

using System.Data;
using MySqlConnector;

string m_strMySQLConnectionString;
m_strMySQLConnectionString = "server=localhost;userid=root;password=root;database=db_india;port=6033";

DisplayMainMenu();

void DisplayMainMenu()
{
    while (true)
    {
        Console.Title = "MySneakers - Menu";
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.White;

        int optionWelcome = 1;
        bool isSelectedWelcome = false;
        string colorWelcome = "    \u001B[32m";

        while (!isSelectedWelcome)
        {
            int topWelcome = Console.WindowHeight / 2;

            string welcome = @"
██████  ██ ███████ ███    ██ ██    ██ ███████ ███    ██ ██    ██ ███████ 
██   ██ ██ ██      ████   ██ ██    ██ ██      ████   ██ ██    ██ ██      
██████  ██ █████   ██ ██  ██ ██    ██ █████   ██ ██  ██ ██    ██ █████   
██   ██ ██ ██      ██  ██ ██  ██  ██  ██      ██  ██ ██ ██    ██ ██      
██████  ██ ███████ ██   ████   ████   ███████ ██   ████  ██████  ███████ 
";

            string[] welcomeLines = welcome.Split("\n");
            int welcomeHeight = Console.WindowHeight / 2 - 6;

            for (int i = 0; i < welcomeLines.Length; i++)
            {
                Console.CursorLeft = Console.WindowWidth / 2 - (welcomeLines[i].Length / 2 - 4);
                Console.CursorTop = welcomeHeight + i;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(welcomeLines[i]);
            }

            Console.SetCursorPosition((Console.WindowWidth - "Import".Length) / 2, topWelcome + 3);
            Console.WriteLine($"{(optionWelcome == 1 ? colorWelcome : "    ")}Import\u001b[0m");

            Console.SetCursorPosition((Console.WindowWidth - "Quitter".Length) / 2, topWelcome + 4);
            Console.WriteLine($"{(optionWelcome == 2 ? colorWelcome : "    ")}Quitter\u001b[0m");

            var keyWelcome = Console.ReadKey(true);

            switch (keyWelcome.Key)
            {
                case ConsoleKey.UpArrow:
                    optionWelcome = optionWelcome == 1 ? 2 : optionWelcome - 1;
                    break;

                case ConsoleKey.DownArrow:
                    optionWelcome = optionWelcome == 2 ? 1 : optionWelcome + 1;
                    break;

                case ConsoleKey.Enter:
                    isSelectedWelcome = true;
                    break;
            }
        }


        if (optionWelcome == 1)
        {
            Import();
        }
        else if (optionWelcome == 2)
        {
            Exitprogram();
        }
    }
}

void Import()
{
    Console.Clear();

    using (var mysqlconnection = new MySqlConnection(m_strMySQLConnectionString))
    {
        mysqlconnection.Open();
        int added = 0;

        string filepath = @"C:\Users\pt50cuy\Desktop\HTML_PHP\99. TEST\src\consignes\msig-prog-eval3-erp1-data.csv";

        try
        {
            foreach (string line in File.ReadAllLines(filepath))
            {
                var columns = line.Split(";");
                string Rating = columns[0];
                string CompanyName = columns[1];
                string JobTitle = columns[2].ToLower().Replace(" ", "-");
                string Salary = columns[3];
                string SalariesReported = columns[4];
                string Location = columns[5];

                var CHF = Convert.ToDouble(Salary) * 0.011;

                string imageName = image(JobTitle);

                if (Convert.ToDouble(Rating) >= 3)
                {
                    string sql = @"
INSERT INTO t_job (jobRating, jobCompanyName, jobJobTitle, jobSalary, jobSalariesReported, jobLocation, jobCHF, jobImage )
VALUES
(@Rating, @CompanyName, @JobTitle, @Salary, @SalariesReported, @Location, @CHF, @image)";

                    using (MySqlCommand cmd = mysqlconnection.CreateCommand())
                    {
                        cmd.Parameters.AddWithValue("@Rating", Rating);
                        cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                        cmd.Parameters.AddWithValue("@JobTitle", JobTitle);
                        cmd.Parameters.AddWithValue("@Salary", Salary);
                        cmd.Parameters.AddWithValue("@SalariesReported", SalariesReported);
                        cmd.Parameters.AddWithValue("@Location", Location);
                        cmd.Parameters.AddWithValue("@CHF", CHF);
                        cmd.Parameters.AddWithValue("@image", imageName);


                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 300;
                        cmd.CommandText = sql;

                        added = added + cmd.ExecuteNonQuery();
                        Console.WriteLine($"{Rating} {CompanyName} {JobTitle} {Salary} {SalariesReported} {Location} {CHF} {imageName}");
                    }
                }
            }
            Console.WriteLine($"Added {added} records...");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            mysqlconnection.Close();
        }

        Console.ReadLine();
    }
}

string image(string ImageName)
{
    if (ImageName.Contains("android"))
    {
        string image = ImageName.Replace(ImageName, "droid.png");
        return image;
    }
    else if (ImageName.Contains("python"))
    {
        string image = ImageName.Replace(ImageName, "python.png");
        return image;
    }
    else if (ImageName.Contains("ios"))
    {
        string image = ImageName.Replace(ImageName, "mac.png");
        return image;
    }
    else if (ImageName.Contains("sde"))
    {
        string image = ImageName.Replace(ImageName, "dev.png");
        return image;
    }
    else
    {
        string image = ImageName.Replace(ImageName, "empty.png");
        return image;
    }
}

void Exitprogram()
{
    Console.Clear();
    Console.Title = "Job-India - Quit";

    Console.ForegroundColor = ConsoleColor.White;

    Console.CursorVisible = false;
    string goodbyeText = @"
         █████  ██    ██     ██████  ███████ ██    ██  ██████  ██ ██████  
        ██   ██ ██    ██     ██   ██ ██      ██    ██ ██    ██ ██ ██   ██ 
        ███████ ██    ██     ██████  █████   ██    ██ ██    ██ ██ ██████  
        ██   ██ ██    ██     ██   ██ ██       ██  ██  ██    ██ ██ ██   ██ 
        ██   ██  ██████      ██   ██ ███████   ████    ██████  ██ ██   ██ 
        ";
    string[] goodbyeScreen = goodbyeText.Split("\n");
    int goodbyeScreenHeight = Console.WindowHeight / 2 - 6;

    for (int i = 0; i < goodbyeScreen.Length; i++)
    {
        Console.CursorLeft = Console.WindowWidth / 2 - (goodbyeScreen[i].Length / 2 - 2);
        Console.CursorTop = goodbyeScreenHeight + i;
        Console.WriteLine(goodbyeScreen[i]);
    }

    Thread.Sleep(500);
    Environment.Exit(0);
}