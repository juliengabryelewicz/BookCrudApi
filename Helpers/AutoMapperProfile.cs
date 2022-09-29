namespace BookCrudApi.Helpers;

using AutoMapper;
using BookCrudApi.Entities;
using BookCrudApi.Dto.Books;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {

        CreateMap<CreateRequest, Book>();

        CreateMap<UpdateRequest, Book>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;
                    return true;
                }
            ));
    }
}