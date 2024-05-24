using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Abstractions
{

    //public interface ICachedQuery<TResponse>: IRequest<TResponse>,ICachedQuery
    //{
    //}
    public interface ICachedQuery
    {
        public string Key { get; }
    }
}
