using System;
using Volunteering.Data;

namespace Volunteering.Service
{
    public class AppService
    {
        public delegate AppContext Del();

        public AppContext AppContext { get; set; }

        public Del CreateDel = AppContext.Create;

        public object Test = AppContext.Create();

        //public Func<T> AaaFunc = Aaa;


        public IDisposable aaa()
        {
            return new AppContext();
        }


        public static AppContext Aaa()
        {
            return new AppContext();
        }


        //app.CreatePerOwinContext();

        public IDisposable CreateContext()
        {
            return new AppContext();
        }

        public AppContext GetContext()
        {
            return new AppContext();

        }

    }
}
