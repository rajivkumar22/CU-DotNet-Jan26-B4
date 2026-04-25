using InsureTrust.API.DTOs.Payment;
using InsureTrust.API.Repositories;
using InsureTrust.API.Services;
using Moq;
using NUnit.Framework;

namespace InsureTrust.Tests;

[TestFixture]
public class PaymentServiceTests
{
    private Mock<IPaymentRepository> _paymentRepoMock;
    private PaymentService _paymentService;

    [SetUp]
    public void Setup()
    {
        _paymentRepoMock = new Mock<IPaymentRepository>();
        _paymentService = new PaymentService(_paymentRepoMock.Object);
    }

    [TestCase(5000, "CreditCard")]
    [TestCase(10000, "UPI")]
    [TestCase(15000, "NetBanking")]
    public async Task InitiateAsync_ShouldInitiatePayment_WithDifferentAmounts(decimal amount, string method)
    {
        // Arrange
        var dto = new InitiatePaymentDto { UserPolicyId = 1, Amount = amount, PaymentMethod = method };

        // Act
        var result = await _paymentService.InitiateAsync(dto, 1);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Amount, Is.EqualTo(amount));
        Assert.That(result.PaymentMethod, Is.EqualTo(method));
        Assert.That(result.Status, Is.EqualTo("Success"));
    }
}
