using MediatR;
using User.App.Interfaces;

namespace User.App.Requests
{
    public class LoginClientQuery : IRequest<string>
    {
        public string clientEmail { get; set; }
        public string clientPassword { get; set; }
    }
    public class LoginClientHandler : IRequestHandler<LoginClientQuery, string>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJWTProvider _jwtProvider;
        public LoginClientHandler(IClientRepository clientRepository, IPasswordHasher passwordHasher, IJWTProvider jWTProvider)
        {
            _clientRepository = clientRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jWTProvider;
        }
        public async Task<string> Handle(LoginClientQuery query, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByEmail(query.clientEmail);
            var compareResult = _passwordHasher.Verify(query.clientPassword, client.passwordHash);
            if (!compareResult) throw new UnauthorizedAccessException("Wrong password.");
            var token = _jwtProvider.GenerateToken(client);
            return token;
        }
    }
}
