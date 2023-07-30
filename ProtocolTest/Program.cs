//using Hero;
//using Test;

using System.Text;

namespace ProtocolTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string str = "序列号";
            var bytes = System.Text.Encoding.UTF8.GetBytes(str);
            var sl = bytes.Select(x => x.ToString());
            StringBuilder sb = new StringBuilder();
            
            foreach (var item in sl)
            {
                sb.Append(item);
            }
            Console.WriteLine(sb.ToString());
            //MyProtocol myProtocol = new MyProtocol();
            //myProtocol.ID = 10;
            //int offset = 0;
            //byte[] data = new byte[10];
            //myProtocol.Write(data,ref offset);

            //HeroInfo heroInfo=new HeroInfo();
            //List<Hero.MyEnum> myEnums= new List<Hero.MyEnum>();
            //myEnums.Add(Hero.MyEnum.One);
            //myEnums.Add(Hero.MyEnum.Two);
            //List<Hero.MyEnum> myEnums1= new List<Hero.MyEnum>();
            //myEnums1.Add(Hero.MyEnum.Three);
            //myEnums1.Add(Hero.MyEnum.Four);
            //heroInfo.list.Add(myEnums);
            //heroInfo.list.Add(myEnums1);

            //int offset = 0;
            //byte[] data = new byte[1024];
            //heroInfo.Write(data,ref offset);

            //HeroInfo hero =new HeroInfo();
            //offset= 0;
            //hero.Read(data,ref offset);

            //Console.WriteLine(hero.list.Count);
            //Console.WriteLine(hero.list[0].Count);
            //Console.WriteLine(hero.list[1].Count);
            //Console.WriteLine(hero.list[0][0]);
            //Console.WriteLine(hero.list[0][1]);
            //Console.WriteLine(hero.list[1][0]);
            //Console.WriteLine(hero.list[1][1]);
        }
    }
}