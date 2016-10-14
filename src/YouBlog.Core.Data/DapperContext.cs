using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouBlog.Core.Data
{
    public class DapperContext
    {
        string _connection;
        public DapperContext()
        {
            
        }

        public string ConnectionString
        {
            set
            {
                _connection = value;
            }
            get
            {
                return _connection;
            }
        }

    }
}
