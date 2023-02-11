
namespace Program
{
    class Program
    {
        public void createStudent()
        {
            try
            {
                StreamWriter writer = new StreamWriter("db.txt", true);
                Console.Write("Enter the number of students you want to create : ");
                int numofStudents = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(" ");
                for (int i = 0; i < numofStudents; i++)
                {
                    Console.Write("Enter the name of the student " + (i + 1) + " : ");
                    string name = Console.ReadLine();
                    Console.Write("Enter the roll number of the student (" + name + ") : ");
                    int roll = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(" ");
                    string toWrite = "\n{ \n Name: " + name + ", \n Roll: " + roll + "\n}";
                    writer.WriteLine(toWrite);
                }
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
                while (line != null)
                {
                    if (line.Contains("Roll: " + roll))
                    {
                        Console.Write("Enter the new name of the student : ");
                        string name = Console.ReadLine();
                        Console.Write("Enter the new roll number of the student : ");
                        int newroll = Convert.ToInt32(Console.ReadLine());
                        string toWrite = "\n{ \n Name: " + name + ", \n Roll: " + newroll + "\n}";
                        StreamWriter writer = new StreamWriter("db.txt", true);
                        writer.WriteLine(toWrite);
                        writer.Close();
                    }

                }
                reader.Close();
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
        public void countStudent()
        {
            try
            {
                StreamReader reader = new StreamReader("db.txt");
                // count how many times the word name appears in the file
                string line = reader.ReadLine();
                if (line == null)
                {
                    Console.WriteLine("No data found");
                    return;
                }
                int count = 0;
                while (line != null)
                {
                    if (line.Contains("Name: "))
                    {
                        count++;
                    }
                    line = reader.ReadLine();
                }
                Console.WriteLine("Number of students are : " + count);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }

        public void deleteIndividual()
        {


        }

        public void getList()
        {
            Console.WriteLine("Enter 1 to insert data");
            Console.WriteLine("Enter 2 to read data");
            Console.WriteLine("Enter 3 to update data");
            Console.WriteLine("Enter 4 to all delete data");
            Console.WriteLine("Enter 5 to count number of students");
            Console.WriteLine("Enter 6 to delete individual student");
            Console.WriteLine("Enter 7 to exit");
            Console.WriteLine("-----------------------------");
        }
        static void Main(string[] args)

        {
            Program obj = new Program();
            obj.getList();
            string isExit = "";
            do
            {
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
                    obj.countStudent();
                }
                if (choice == 6)
                {
                    obj.deleteIndividual();
                }

                if (choice == 7)
                {
                    Console.Write("Exiting the program...");
                    return;
                }
                do
                {
                    Console.Write("Do you want to exit the program? (yes/no) : ");
                    isExit = Console.ReadLine();
                    if (isExit != "no" && isExit != "yes")
                    {
                        Console.WriteLine("Invalid input");
                    }
                    Console.Clear();
                    obj.getList();
                } while (isExit != "no" && isExit != "yes");

            } while (isExit == "no");
            Console.WriteLine("Program exited successfully..");
        }
    }
}