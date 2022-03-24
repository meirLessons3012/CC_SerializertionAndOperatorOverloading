using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace CC_SerializertionAndOperatorOverloading
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            #region File.IO
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));

            //using (Stream myFileWithUsing = new FileStream(@"E:\myFiles\Person.txt", FileMode.Create))
            //{
            //    Person p = new Person { Id = 12124123, FirstName = "Yaron", LastName = "hajbi", PhonePsw = "YH1234" };
            //    xmlSerializer.Serialize(myFileWithUsing, p);
            //}

            //using(Stream myFileWithUsing = new FileStream(@"E:\myFiles\Person.txt", FileMode.Open))
            //{

            //    Person dPers = (Person)xmlSerializer.Deserialize(myFileWithUsing);
            //}

            //#region Directory/File/Path

            //string[] dirs = Directory.GetDirectories(@"E:\myFiles","*.*",SearchOption.AllDirectories);
            //string[] files = Directory.GetFiles(@"C:\Users\meir7\source\repos\System.IO - Input-Output", "*.cs",SearchOption.AllDirectories);

            //foreach(string str in Directory.EnumerateFiles(@"C:\Users\meir7\source\repos\System.IO - Input-Output", "*.cs", SearchOption.AllDirectories))
            //    {
            //    Console.WriteLine(str);
            //}

            ////bool myFilesDirExist = Directory.Exists(@"E:\myFiles");
            ////Directory.CreateDirectory(@"E:\myFiles\DirFromCode1");
            ////Directory.CreateDirectory(@"E:\myFiles\DirFromCode2");
            ////Directory.CreateDirectory(@"E:\myFiles\DirFromCode3");
            ////Directory.Delete(@"E:\myFiles\DirFromCode2");
            ////Directory.Move(@"E:\myFiles\DirFromCode1", @"E:\myFiles\DirFromCode4");
            ////Directory.CreateDirectory(@"E:\myFiles\DirFromCode4\dirForFile");


            //////File.Create(@"E:\myFiles\fileFromCode1.txt");
            //////File.Create(@"E:\myFiles\fileFromCode2.txt");

            //////File.Create(@"E:\myFiles\fileFromCode3.txt");
            ////File.Delete(@"E:\myFiles\fileFromCode2.txt");
            ////File.Copy(@"E:\myFiles\fileFromCode1.txt", @"E:\myFiles\DirFromCode4\fileFromCode1.txt");
            ////File.Move(@"E:\myFiles\fileFromCode3.txt", @"E:\myFiles\DirFromCode4\dirForFile\fileFromCode3.txt");

            //string fileName = Path.GetFileName(@"E:\myFiles\DirFromCode4\fileFromCode1.txt");//fileFromCode1.txt
            //string dirName = Path.GetDirectoryName(@"E:\myFiles\DirFromCode4\fileFromCode1.txt");
            //string fileExtName = Path.GetExtension(@"E:\myFiles\DirFromCode4\fileFromCode1.txt");//txt
            //string fileWithoutName = Path.GetFileNameWithoutExtension(@"E:\myFiles\DirFromCode4\fileFromCode1.txt"); //fileFromCode1
            //string deviceType = "Pc";
            //string dirImagesName = "Images";
            //string imageName = "myAvatar.png";
            //string fullPath = Path.Combine(@"E:\myFiles", dirImagesName, deviceType, imageName);
            //string dirName2 = Path.GetDirectoryName(fullPath);
            //Directory.CreateDirectory(dirName2);
            //File.Create(fullPath);

            //File.OpenRead(fullPath);
            //File.OpenText(fullPath);


            //FileInfo fileInfo = new FileInfo(fullPath);
            //DirectoryInfo directoryInfo = new DirectoryInfo(dirName2);
            //FileInfo[] filesInfo = directoryInfo.GetFiles();

            //double counter = 0;
            //foreach(FileInfo file in filesInfo)
            //{
            //    counter += file.Length;
            //}
            //#endregion
            #endregion

            #region Operator overloading

            Shape shape1 = new Shape();
            Shape shape2 = new Shape();
            Shape shape3 = shape2;

            Console.WriteLine(shape1 == shape2); //type
            Console.WriteLine(shape1.Equals(shape2)); //type
            Console.WriteLine(shape2 == shape3);
            Console.WriteLine(shape2 != shape3);

            Console.WriteLine(shape1 + shape2);
            Shape resShape = shape1 + shape2;

            Console.WriteLine(shape1 - shape2);
            Shape resMinusShape = shape1 - shape2;

            #endregion

            #region Extension Method

            string myName = "MEIR";
            string lastLowerCase = myName.LastLowerCase();
            string someChars = myName.GetSomeChars(3);
            MyStringExtentions.LastLowerCase("SHALOM CITA A");

            Random random = new Random();
            random.GetRandomNumberWithout357(1, 10);
            #endregion


        }
        public static string ShortIf(Shape sh1, Shape sh2)
        {
            return sh1.Type.Length > sh2.Type.Length ? sh1.Type : sh1.Type.Length == sh2.Type.Length ? "" : sh2.Type;

            //long way
            //if (sh1.Type.Length > sh2.Type.Length)
            //{
            //    return sh1.Type;
            //}
            //else if (sh1.Type.Length == sh2.Type.Length)
            //{
            //    return "";
            //}
            //else
            //{
            //    return sh2.Type;
            //}
        }
    }

    public class Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public string Type { get; set; }

        public Shape()
        {


            Height = CreateRandomDouble();
            Width = CreateRandomDouble();
            Type = CreateRandomString(8);
        }



        public static bool operator ==(Shape sh1, Shape sh2)
        {
            if (object.ReferenceEquals(sh1, null) && object.ReferenceEquals(sh2, null))
                return true;
            if (object.ReferenceEquals(sh1, null) || object.ReferenceEquals(sh2, null))
                return false;

            return sh1.Type == sh2.Type;
        }

        public static bool operator !=(Shape sh1, Shape sh2)
        {
            return !(sh1 == sh2);
        }

        public static bool operator >(Shape sh1, Shape sh2)
        {
            return sh1.Height > sh2.Height && sh1.Width > sh2.Width;
        }

        public static bool operator <(Shape sh1, Shape sh2)
        {
            return sh1.Height < sh2.Height && sh1.Width < sh2.Width;
        }

        public static bool operator >=(Shape sh1, Shape sh2)
        {
            return !(sh1 < sh2);
        }

        public static bool operator <=(Shape sh1, Shape sh2)
        {
            return !(sh1 > sh2);
        }

        public static Shape operator +(Shape sh1, Shape sh2)
        {
            Shape resShape = new Shape();
            resShape.Type = sh1.Type + sh2.Type;
            resShape.Height = sh1.Height + sh2.Height;
            resShape.Width = sh1.Width + sh2.Width;
            return resShape;
        }

        public static Shape operator -(Shape sh1, Shape sh2)
        {
            string maxType = sh1.Type.Length >= sh2.Type.Length ? sh1.Type : sh2.Type;
            double maxHeight = sh1.Height >= sh2.Height ? sh1.Height : sh2.Height;
            double maxWidht = sh1.Width >= sh2.Width ? sh1.Width : sh2.Width;

            double minHeight = sh1.Height >= sh2.Height ? sh2.Height : sh1.Height;
            double minWidht = sh1.Width >= sh2.Width ? sh2.Width : sh1.Width;


            Shape resShape = new Shape();
            resShape.Type = maxType;
            resShape.Height = maxHeight - minHeight;
            resShape.Width = maxWidht - minWidht;
            return resShape;
        }


        public override bool Equals(object obj)
        {
            return (obj as Shape) == this;
        }

        public override int GetHashCode()
        {
            return 100;
        }

        public static double CreateRandomDouble()
        {
            Random r = new Random();
            return r.NextDouble() * 10;
        }


        public static string CreateRandomString(int length)
        {
            Random r = new Random();
            System.Text.StringBuilder str_build = new System.Text.StringBuilder();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = r.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }

        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }
    }
}
