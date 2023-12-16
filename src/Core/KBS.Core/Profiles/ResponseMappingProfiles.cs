using AutoMapper;
using KBS.Core.Responses;

namespace KBS.Core.Profiles;
public class ResponseMappingProfiles : Profile
{
    public ResponseMappingProfiles()
    {
        CreateMap(typeof(ResponseResult<>), typeof(BaseResponseResult)).ReverseMap();
    }
}
