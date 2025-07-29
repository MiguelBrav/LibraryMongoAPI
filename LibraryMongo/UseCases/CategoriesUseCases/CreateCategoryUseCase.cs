﻿using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Infrastructure.Repositories;
using LibraryMongo.Models.DTOs;
using LibraryMongo.Models.Entities;

namespace LibraryMongo.UseCases.CategoriesUseCases;

public class CreateCategoryUseCase : UseCaseBase<CreateCategoryDTO>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public override async Task<IResult> Execute(CreateCategoryDTO request)
    {
        try
        {
            if (request.Name == null || !request.Name.Any())
            {
                return TypedResults.BadRequest("Name dictionary is required and cannot be empty.");
            }

            Category category = new Category
            {
                Name = request.Name
            };

            await _categoryRepository.CreateAsync(category);

            return TypedResults.Created($"/categories/{category.Id}", category);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}
