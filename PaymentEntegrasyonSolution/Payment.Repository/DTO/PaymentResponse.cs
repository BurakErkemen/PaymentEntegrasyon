using System.Net;

namespace Payment.Repository.DTO;
public record PaymentResponse(
    bool Code,
    string PaymentId,
    string Message
    );

