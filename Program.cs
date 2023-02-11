
namespace Program
{
    class Program
    {
        public void createStudent()
        {
            try
            {
                StreamWriter writer = new StreamWriter("db.txt", true);
                Console.Write("Enter the name of the student : ");
                string name = Console.ReadLine();
                Console.Write("Enter the roll number of the student : ");
                int roll = Convert.ToInt32(Console.ReadLine());
                string toWrite = "\n{ \n Name: " + name + ", \n Roll: " + roll + "\n}";
                writer.WriteLine(toWrite);
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("Data inserted successfully");
            }
        }
        public void readallStudent()
        {
            try
            {

                StreamReader reader = new StreamReader("db.txt");
                string line = reader.ReadLine();
                if (line == null)
                {
                    Console.WriteLine("No data found");
                    return;
                }

                Console.WriteLine("All the records of students are :");
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        public void updateStudent()

        {
            try
            {
                Console.Write("Enter the roll number of the student to update : ");
                int roll = Convert.ToInt32(Console.ReadLine());
                StreamReader reader = new StreamReader("db.txt");
                string line = reader.ReadLine();
                if (line == null)
                {
                    Console.WriteLine("No data found");
                    return;
                }
                string toWrite = "";
                while (line != null)
                {
                    if (line.Contains("Roll: " + roll))
                    {
                        Console.Write("Enter the name of the student : ");
                        string name = Console.ReadLine();
                        toWrite += "\n{ \n Name: " + name + ", \n Roll: " + roll + "\n}";
                    }
                    else
                    {
                        toWrite += line;
                    }
                    line = reader.ReadLine();
                }
                reader.Close();
                StreamWriter writer = new StreamWriter("db.txt", true);
                writer.WriteLine(toWrite);
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("Data updated successfully");
            }
        }
        public void deleteallData()
        {
            try
            {
                StreamWriter writer = new StreamWriter("db.txt", false);
                writer.WriteLine("");
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("Data cleared successfully");
            }
        }
        static void Main(string[] args)

        {
            Program obj = new Program();

            Console.WriteLine("Enter 1 to insert data");
            Console.WriteLine("Enter 2 to read data");
            Console.WriteLine("Enter 3 to update data");
            Console.WriteLine("Enter 4 to delete data");
            Console.WriteLine("Enter 5 to exit");
            Console.WriteLine("-----------------------------");
            Console.Write("Enter your choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                obj.createStudent();
            }

            if (choice == 2)
            {
                obj.readallStudent();
            }

            if (choice == 3)
            {
                obj.updateStudent();
            }
            if (choice == 4)
            {
                obj.deleteallData();
            }

            if (choice == 5)
            {
                Console.Write("Exiting the program...");
                return;
            }

        }
    }
}