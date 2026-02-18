namespace Day_15_Role_Based_Authorization.DTOs
{
    public record EmployeeCreateDto(string Name, string? Position, decimal Salary);
    public record EmployeeUpdateDto(string Name, string? Position, decimal Salary);
}
