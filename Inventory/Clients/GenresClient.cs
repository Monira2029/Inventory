using Inventory.Models;

namespace Inventory.Clients;

public class GenresClient
{
    private readonly Genre[] genres =
    [
        new(){
            Id = 1,
            Name = "Cricket"
        },
        new(){
            Id = 2,
            Name = "Football"
        },
        new(){
            Id = 3,
            Name = "Handball"
        },
        new(){
            Id = 4,
            Name = "Hadudu"
        },
        new(){
            Id = 5,
            Name = "Gollachut"
        }
    ];

    public Genre[] GetGenres() => genres;
}