﻿namespace BookStore.WebApi.Responses
{
    public record LinkDto(
        string? Href,
        string? Rel,
        string? Method
    );
}
