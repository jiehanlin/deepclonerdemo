using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepClonerDemo;
using DeepClonerDemo.AppModel;

namespace AppServices
{
    public class DictService:IDictService
    {
        public readonly DbContext _DbContext;
        public DictService(Model1Container db)
        {
            _DbContext = db;
            //set true will throw exception on mvc project
            _DbContext.Configuration.ProxyCreationEnabled = true;
        }
        public IList<DataDictionaryType> GetDictType()
        {
            return _DbContext.Set<DataDictionaryType>().ToList();
        }
    }
}
