using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllers();

// Serve a simple HTML page at the root
app.MapGet("/", () => Results.Content(@"
<!DOCTYPE html>
<html>
<head>
    <title>🔥 FIRE Calculator 🔥</title>
    <style>
        body { font-family: Arial, sans-serif; max-width: 600px; margin: 50px auto; padding: 20px; }
        .container { background: #f5f5f5; padding: 30px; border-radius: 10px; }
        input, button { padding: 10px; margin: 10px 0; font-size: 16px; }
        input { width: 200px; }
        button { background: #007bff; color: white; border: none; border-radius: 5px; cursor: pointer; }
        button:hover { background: #0056b3; }
        .result { margin-top: 20px; padding: 15px; background: #d4edda; border-radius: 5px; display: none; }
    </style>
</head>
<body>
    <div class='container'>
        <h1>🔥 FIRE Calculator 🔥</h1>
        <div>
            <label>Annual Expenses (€):</label><br>
            <input type='number' id='expenses' placeholder='50000'>
        </div>
        <div>
            <label>Safe Withdrawal Rate (e.g., 0.04 for 4%):</label><br>
            <input type='number' id='swr' placeholder='0.04' step='0.01'>
        </div>
        <button onclick='calculate()'>Calculate FIRE Number</button>
        <div id='result' class='result'></div>
    </div>
    <script>
        async function calculate() {
            const expenses = parseFloat(document.getElementById('expenses').value);
            const swr = parseFloat(document.getElementById('swr').value);
            
            if (!expenses || !swr) {
                alert('Please enter both values');
                return;
            }
            
            const response = await fetch('/api/fire/calculate', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ expenses, swr })
            });
            
            const result = await response.json();
            const resultDiv = document.getElementById('result');
            resultDiv.innerHTML = `<strong>Your FIRE number is: €${result.fireNumber.toLocaleString()}</strong>`;
            resultDiv.style.display = 'block';
        }
    </script>
</body>
</html>
", "text/html"));

app.Run();

