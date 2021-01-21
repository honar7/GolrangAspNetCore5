using System;

namespace Session4.Configurations
{
    class Program
    {
        static void Main(string[] args)
        {
            //ShadowProp();

            Console.WriteLine("Hello World!");
        }

        private static void ShadowProp()
        {
            ShadowProp prop = new ShadowProp();

            var ctx = new MyDbContextTest();
            ctx.Add(prop);
            ctx.Entry(prop).Property<DateTime>("UpdateDate").CurrentValue = DateTime.Now;
            ctx.Entry(prop).Property<DateTime>("InsertDate").CurrentValue = DateTime.Now;
            ctx.Entry(prop).Property<int>("InsertBy").CurrentValue = 1;
            ctx.Entry(prop).Property<int>("UpdateBy").CurrentValue = 1;
            var id = ctx.Entry(prop).Property<int>("UpdateBy").CurrentValue;
        }
    }
}
