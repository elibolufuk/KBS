using KBS.CreditAppSys.Persistence.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace KBS.CreditAppSys.Persistence.Extensions;

internal static class ModelBuilderExtensions
{
    public static EntityTypeBuilder SeedTypeData<TEnum, TId>(this EntityTypeBuilder builder)
        where TId : struct, IComparable<TId>, IEquatable<TId>
    {
        var enumType = Enum.GetValues(typeof(TEnum));
        List<object> typeData = [];

        foreach (var item in enumType)
            typeData.Add(new { Id = (TId)item, Name = item.ToString() });

        if (typeData?.Count > 0)
            builder.HasData(typeData);

        return builder;
    }

    public static EntityTypeBuilder SeedData<TEntity, TId>(this EntityTypeBuilder builder)
        where TEntity : class
        where TId : struct, IComparable<TId>, IEquatable<TId>
    {
        var jsonFile = string.Format(SeedDataConstants.JsonFileFormat, typeof(TEntity).Name);
        if (File.Exists(jsonFile))
            using (StreamReader sr = new(jsonFile))
            {
                var json = sr.ReadToEnd();
                if (json != null)
                {
                    var data = JsonConvert.DeserializeObject<List<TEntity>>(json);
                    if (data != null)
                        builder.HasData(data);
                }
            }
        return builder;
    }
}
