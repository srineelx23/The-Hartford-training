namespace Exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter A circle Cordinates and Radius: ");
            int ax = Convert.ToInt32(Console.ReadLine());
            int ay = Convert.ToInt32(Console.ReadLine());
            int ar= Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(ax+" "+ay+" "+ar);
            Console.WriteLine("Enter B circle Cordinates and Radius: ");
            int bx = Convert.ToInt32(Console.ReadLine());
            int by = Convert.ToInt32(Console.ReadLine());
            int br = Convert.ToInt32(Console.ReadLine());

            double d = Math.Sqrt((ax - bx) * (ax - bx) + (ay - by) * (ay - by));
            if(d+br < ar)
            {
                Console.WriteLine("B is in A");
            }
            else if(d + ar < br)
            {
                Console.WriteLine("A is in B");
            }
            else if(Math.Abs(ar-br)<=d && d<=(ar+br))
            {
                Console.WriteLine("A and B Instersect");
            }
            else
            {
                Console.WriteLine("A and B do not intersect");
            }
        }
    }
}
