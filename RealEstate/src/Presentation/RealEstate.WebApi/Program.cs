namespace RealEstate.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
             ORM,Entity FrameworkCore,DbContext

            Object Relational Mapping
             */



            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
