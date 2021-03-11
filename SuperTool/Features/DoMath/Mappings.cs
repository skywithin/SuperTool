using AutoMapper;

namespace SuperTool.Features.DoMath
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Commands.DoMathCommand, DoMath.Request>();
        }
    }
}
