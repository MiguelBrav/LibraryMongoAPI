using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.DTOs;
using LibraryMongo.Models.Entities;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.FeatureFlagsUseCases;

public class CreateFeatureFlagUseCase : UseCaseBase<CreateFeatureFlagDTO, IResult>
{
    private readonly IFeatureFlagRepository _featureFlagRepository;

    public CreateFeatureFlagUseCase(IFeatureFlagRepository featureFlagRepository)
    {
        _featureFlagRepository = featureFlagRepository;
    }

    public override async Task<IResult> Execute(CreateFeatureFlagDTO request)
    {
        try
        {
            if (request.Name == null || !request.Name.Any())
            {
                return TypedResults.BadRequest("Name dictionary is required and cannot be empty.");
            }

            if (request.Description == null || !request.Description.Any())
            {
                return TypedResults.BadRequest("Description dictionary is required and cannot be empty.");
            }

            FeatureFlag flag = new FeatureFlag
            {
                Name = request.Name,
                Description = request.Description,
                Enabled = request.Enabled,
            };

            await _featureFlagRepository.CreateAsync(flag);

            return TypedResults.Created($"/featureflags/{flag.Id}", new { Name = flag.Name, Id = flag.Id.ToString() });
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}
