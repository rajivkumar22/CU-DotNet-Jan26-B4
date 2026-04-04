# SmartBank API Gateway

## Overview
YARP-based API Gateway that provides a unified entry point for all SmartBank microservices.

## Configuration

### Port
- **HTTPS**: https://localhost:7000
- **HTTP**: http://localhost:5000

### Routes
| Route Pattern | Destination | Service |
|--------------|-------------|---------|
| `/api/auth/{**catch-all}` | https://localhost:7001 | AuthService |
| `/api/accounts/{**catch-all}` | https://localhost:7002 | AccountService |
| `/api/transaction/{**catch-all}` | https://localhost:7185 | TransactionService |

## Running the Gateway

### Prerequisites
All backend services must be running before starting the gateway:
1. SmartBank.AuthService (port 7001)
2. SmartBank.AccountService (port 7002)
3. SmartBank.TransactionService (port 7185)

### Start Gateway
```bash
cd SmartBank.GatewayApi
dotnet run
```

The gateway will start on https://localhost:7000

## Features
- ✅ Reverse proxy using YARP 2.3.0
- ✅ Routes requests to appropriate backend services
- ✅ Forwards all headers including Authorization tokens
- ✅ Configuration-based routing (appsettings.json)

## Testing

### With Web Application
1. Start all backend services
2. Start the gateway
3. Start SmartBank.Web
4. Access the web app and perform operations (register, login, create account, deposit, withdraw)

### With API Tools (Postman/curl)
```bash
# Register user
curl -X POST https://localhost:7000/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{"username":"test","email":"test@example.com","password":"Test@123","role":"Customer"}'

# Login
curl -X POST https://localhost:7000/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{"email":"test@example.com","password":"Test@123"}'

# Get accounts (requires JWT token)
curl -X GET https://localhost:7000/api/accounts \
  -H "Authorization: Bearer YOUR_JWT_TOKEN"
```

## Architecture
```
SmartBank.Web
     ↓
Gateway :7000 (YARP Reverse Proxy)
     ├─→ AuthService :7001
     ├─→ AccountService :7002
     └─→ TransactionService :7185
```

## Technology Stack
- YARP (Yet Another Reverse Proxy) 2.3.0
- .NET 8.0
- Configuration-based routing
