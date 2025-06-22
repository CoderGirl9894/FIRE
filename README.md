# 🔥 FIRE Calculator

A web application to calculate your Financial Independence, Retire Early (FIRE) number based on your annual expenses and safe withdrawal rate.

## 🚀 Features

- **Web-based FIRE Calculator**: Calculate your FIRE number with a simple, intuitive interface
- **API Endpoint**: RESTful API for programmatic access to calculations
- **Responsive Design**: Works on desktop and mobile devices
- **Real-time Calculations**: Instant results as you input your data

## 🛠️ Technology Stack

- **Backend**: .NET 9.0 Web API
- **Frontend**: HTML, CSS, JavaScript
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

## 🚀 Deployment

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
├── Program.cs                 # Application entry point
├── FireCalculator.csproj      # Project configuration
├── Dockerfile                 # Container configuration
└── README.md                  # This file
```

---

# 🔧 DESIGN GUIDELINES

This file outlines the design principles, UI expectations, and styling rules to be followed **before making any UI/UX changes** to the FIRE Calculator App. It is meant for developers (including AI like Cursor) working on this codebase.

## 🎨 Color Palette

Only use the following 5 colors as your **primary** design palette. These should be referenced in Tailwind via custom config (or using Tailwind's extended colors if mapped).

| Light Blue | Teal | Navy | Gold | Orange |
|------------|------|------|------|--------|
| `#94D2F5`  | `#24A4C4` | `#002B45` | `#FFC107` | `#FF8C00` |

Use these colors thoughtfully:
- Use **Navy (`#002B45`)** for headers, accents, and key contrast elements.
- Use **Teal (`#24A4C4`)** and **Light Blue (`#94D2F5`)** for backgrounds, info cards, and calming UI.
- Use **Gold (`#FFC107`)** and **Orange (`#FF8C00`)** sparingly to highlight actions, call-to-actions, or important figures.

## 🧩 Tailwind CSS Usage

✅ **Use Tailwind CSS for all styling** — no inline styles or custom CSS unless absolutely required.

✅ Keep it simple and accessible — don't overcomplicate animations or custom elements.

- ❌ Don't use random colors or gradients outside the defined palette. 
- ❌ Don't overwrite Tailwind with custom CSS files unless it's a theme-wide fix.

- Fonts: Stick with system fonts or Tailwind's default stack (`font-sans`)

---

✅ Follow this guide to keep the design clean, fast, and consistent. All PRs and auto-generated UI changes must align with this document.

## 📝 License

This project is open source and available under the [MIT License](LICENSE).

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes following the design guidelines
4. Submit a pull request

---

**Built with ❤️ for the FIRE community** 