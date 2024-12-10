namespace mvc.Models;

public class Student
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }

    // Propriété calculée pour afficher le nom complet
    public string Name => $"{Firstname} {Lastname}";
}
