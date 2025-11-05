using Inventory.Models;

namespace Inventory.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games = [
   new(){
        Id = 1,
        Name = "Cricket",
        Genre = "Cricket",
        Price = 20.00M,
        ReleaseDate = new DateOnly(1971, 5, 5)
    },
    new(){
        Id = 2,
        Name = "Football",
        Genre = "Football",
        Price = 40.00M,
        ReleaseDate = new DateOnly(1981, 6, 15)
    },
    new(){
        Id = 3,
        Name = "Handball",
        Genre = "Handball",
        Price = 60.00M,
        ReleaseDate = new DateOnly(1991, 7, 25)
    },
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);

        var genre = genres.Single(genre => genre.Id == int.Parse(game.GenreId));

        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = game.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(gameSummary);

    }
}