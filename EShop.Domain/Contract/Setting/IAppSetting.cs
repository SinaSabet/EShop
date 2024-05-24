using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Contract.Setting
{
    public interface IAppSetting
    {
        public string ConnectionString { get; set; }

    }
}
