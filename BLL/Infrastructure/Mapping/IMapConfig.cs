using AutoMapper;

namespace BL.Infrastructure
{
    public interface IMapConfig
    {
        IMapper GetMapper();
    }
}