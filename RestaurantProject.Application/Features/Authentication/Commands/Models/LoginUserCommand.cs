using MediatR;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.Authentication;

namespace RestaurantProject.Application.Features.Authentication.Commands.Models;
public record LoginUserCommand(LoginRequest LoginRequest) : IRequest<Result<AuthResponse>>;
