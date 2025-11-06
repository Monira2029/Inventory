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
        GetGenryById(game.GenreId);

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

    public  GameDetails GetGame(int id)
    {
        GameSummary game = GetGameSummaryById(id);
        var genre = genres.Single(genre => string.Equals(
            genre.Name,
            game.Genre,
            StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public void UpdateGame(GameDetails updatedGame)
    {
        var genre = GetGenryById(updatedGame.GenreId);
        GameSummary existingGame = GetGameSummaryById(updatedGame.Id);
        existingGame.Name = updatedGame.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    public void DeleteGame(int id)
    {
        var game = GetGameSummaryById(id);
        games.Remove(game);
    }
    private GameSummary GetGameSummaryById(int id)
    {
        GameSummary? game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenryById(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);

        return genres.Single(genre => genre.Id == int.Parse(id));
    }
}