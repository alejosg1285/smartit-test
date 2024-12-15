using Api.Dto;
using Domain;

namespace Api.Extensions;

public static class DataEntityExtension
{
    public static AppUser fromDto(this UserRegistrationDto dto)
    {
        return new AppUser
        {
            DisplayName = dto.DisplayName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            UserName = dto.Email,
        };
    }
}
