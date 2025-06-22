# 🔥 FIRE Calculator

A web application to calculate your Financial Independence, Retire Early (FIRE) number based on your annual expenses and safe withdrawal rate.

---

# 🎨 DESIGN GUIDELINES - READ FIRST!

**⚠️ IMPORTANT: Before making ANY UI/UX changes or generating code, you MUST follow these design guidelines.**

This section outlines the design principles, UI expectations, and styling rules that **ALL developers and AI assistants** must follow when working on this codebase.

## 🎨 Color Palette

**ONLY use these 5 colors as your primary design palette:**

| Light Blue | Teal | Navy | Gold | Orange |
|------------|------|------|------|--------|
| `#94D2F5`  | `#24A4C4` | `#002B45` | `#FFC107` | `#FF8C00` |

### Color Usage Rules:
- **Navy (`#002B45`)**: Headers, accents, key contrast elements
- **Teal (`#24A4C4`)**: Primary backgrounds, info cards, calming UI
- **Light Blue (`#94D2F5`)**: Secondary backgrounds, subtle highlights
- **Gold (`#FFC107`)**: Call-to-actions, important buttons (use sparingly)
- **Orange (`#FF8C00`)**: Critical actions, warnings (use very sparingly)

## 🧩 Styling Requirements

### ✅ DO:
- Use **Tailwind CSS classes** for all styling
- Keep designs simple and accessible
- Use system fonts (`font-sans`)
- Follow the color palette strictly
- Make UI responsive and mobile-friendly

### ❌ DON'T:
- Use random colors outside the defined palette
- Add custom CSS files unless absolutely necessary
- Overcomplicate animations or custom elements
- Use gradients or complex visual effects
- Override Tailwind with custom styles

## 🔧 Code Generation Rules

**When generating or editing code, ALWAYS:**
1. Reference this color palette for any styling
2. Use Tailwind CSS classes instead of inline styles
3. Keep the design clean and consistent
4. Follow the established UI patterns

---

# 🚀 Project Overview

## Features

- **Web-based FIRE Calculator**: Calculate your FIRE number with a simple, intuitive interface
- **API Endpoint**: RESTful API for programmatic access to calculations
- **Responsive Design**: Works on desktop and mobile devices
- **Real-time Calculations**: Instant results as you input your data

## Technology Stack

- **Backend**: .NET 9.0 Web API
- **Frontend**: HTML, CSS, JavaScript
- **Styling**: Tailwind CSS (following design guidelines above)
- **Deployment**: Docker containerization
- **Hosting**: Render (cloud platform)

## 📊 How It Works

The FIRE Calculator uses the basic FIRE formula:
```
FIRE Number = Annual Expenses ÷ Safe Withdrawal Rate
```

**Example:**
- Annual Expenses: €50,000
- Safe Withdrawal Rate: 4% (0.04)
- FIRE Number: €1,250,000

## 🌐 Usage

### Web Interface
1. Visit the application URL
2. Enter your annual expenses
3. Enter your safe withdrawal rate (typically 3-4%)
4. Click "Calculate FIRE Number"
5. View your personalized FIRE target

### API Usage
```bash
POST /api/fire/calculate
Content-Type: application/json

{
  "expenses": 50000,
  "swr": 0.04
}
```

Response:
```json
{
  "fireNumber": 1250000,
  "annualExpenses": 50000,
  "withdrawalRate": 0.04
}
```

## 🚀 Development & Deployment

### Local Development
```bash
cd FireCalculator
dotnet run
```
Visit `http://localhost:5000`

### Docker Deployment
```bash
docker build -t fire-calculator .
docker run -p 5000:5000 fire-calculator
```

## 📁 Project Structure

```
FireCalculator/
├── Controllers/
│   └── FireController.cs      # API endpoints
├── Program.cs                 # Application entry point (contains UI)
├── FireCalculator.csproj      # Project configuration
├── Dockerfile                 # Container configuration
└── README.md                  # This file
```

## 📝 License

This project is open source and available under the [MIT License](LICENSE).

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. **Follow the design guidelines above**
4. Make your changes using the specified color palette and Tailwind CSS
5. Submit a pull request

---

**Built with ❤️ for the FIRE community**

*Remember: Always reference the design guidelines when making any UI/UX changes!* 