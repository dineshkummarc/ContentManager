using Db4objects.Db4o;
//
using System.Web;
using System.IO;

namespace ContentNamespace.Web.Code.DataAccess.Db4o
{
    public class Db4O
    {
        static readonly object Lock = new object();
        static IObjectContainer _db;
        static string _dbPath = Resources.EN.Strings.System_ObjectDatabaseConnectionString;
       
        public static string DbPath
        {
            get { return _dbPath; }
            set { _dbPath = value; }
        }

        public static IObjectContainer Container
        {
            get
            {
                lock (Lock)
                {
                    if (_db == null)
                    {
                        if (_dbPath.Contains("|DataDirectory|"))
                        {
                            _dbPath = _dbPath.Replace("|DataDirectory|", "");
                            string appDir = HttpContext.Current.Server.MapPath("~/App_Data/");
                            _dbPath = Path.Combine(appDir, _dbPath);
                        }

                        _db = Db4oFactory.OpenFile(_dbPath);
                    }

                    return _db;
                }
            }
        }

        public static void CloseContainer()
        {
            if (_db != null) { _db.Close(); }

            _db = null;
        }
    }
}
