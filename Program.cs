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
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <style>
        * { margin: 0; padding: 0; box-sizing: border-box; }
        
        body { 
            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, sans-serif; 
            background: linear-gradient(135deg, #94D2F5 0%, #24A4C4 100%);
            min-height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 20px;
        }
        
        .container { 
            background: white; 
            padding: 40px; 
            border-radius: 20px; 
            box-shadow: 0 20px 40px rgba(0, 43, 69, 0.1);
            max-width: 500px;
            width: 100%;
        }
        
        h1 { 
            color: #002B45; 
            text-align: center; 
            margin-bottom: 30px;
            font-size: 2.5rem;
            font-weight: 700;
        }
        
        .input-group {
            margin-bottom: 25px;
        }
        
        label { 
            display: block;
            color: #002B45; 
            font-weight: 600;
            margin-bottom: 8px;
            font-size: 1.1rem;
        }
        
        input { 
            width: 100%;
            padding: 15px;
            border: 2px solid #94D2F5;
            border-radius: 10px;
            font-size: 1.1rem;
            transition: all 0.3s ease;
            background: #f8f9fa;
        }
        
        input:focus {
            outline: none;
            border-color: #24A4C4;
            background: white;
            box-shadow: 0 0 0 3px rgba(36, 164, 196, 0.1);
        }
        
        button { 
            width: 100%;
            background: #FFC107; 
            color: #002B45; 
            border: none; 
            border-radius: 10px; 
            cursor: pointer;
            padding: 15px;
            font-size: 1.2rem;
            font-weight: 600;
            transition: all 0.3s ease;
            margin-top: 10px;
        }
        
        button:hover { 
            background: #FF8C00; 
            transform: translateY(-2px);
            box-shadow: 0 10px 20px rgba(255, 140, 0, 0.3);
        }
        
        .result { 
            margin-top: 25px; 
            padding: 20px; 
            background: linear-gradient(135deg, #24A4C4, #94D2F5); 
            border-radius: 15px; 
            display: none;
            text-align: center;
            color: white;
            font-weight: 600;
            font-size: 1.3rem;
            box-shadow: 0 10px 20px rgba(36, 164, 196, 0.2);
        }
        
        .error {
            background: linear-gradient(135deg, #FF8C00, #FFC107);
            color: white;
        }
        
        .info-text {
            color: #24A4C4;
            font-size: 0.9rem;
            margin-top: 5px;
            font-style: italic;
        }
        
        @media (max-width: 480px) {
            .container { padding: 30px 20px; }
            h1 { font-size: 2rem; }
        }
    </style>
</head>
<body>
    <div class='container'>
        <h1>🔥 FIRE Calculator 🔥</h1>
        
        <div class='input-group'>
            <label>Annual Expenses (€)</label>
            <input type='number' id='expenses' placeholder='50000' min='0'>
            <div class='info-text'>Enter your total annual living expenses</div>
        </div>
        
        <div class='input-group'>
            <label>Safe Withdrawal Rate</label>
            <input type='number' id='swr' placeholder='0.04' step='0.01' min='0.01' max='0.1'>
            <div class='info-text'>Typically 3-4% (0.03-0.04) for long-term sustainability</div>
        </div>
        
        <button onclick='calculate()'>🚀 Calculate My FIRE Number</button>
        <div id='result' class='result'></div>
    </div>
    
    <script>
        async function calculate() {
            const expenses = parseFloat(document.getElementById('expenses').value);
            const swr = parseFloat(document.getElementById('swr').value);
            const resultDiv = document.getElementById('result');
            
            if (!expenses || !swr) {
                resultDiv.innerHTML = '⚠️ Please enter both values';
                resultDiv.className = 'result error';
                resultDiv.style.display = 'block';
                return;
            }
            
            if (swr <= 0 || swr > 0.1) {
                resultDiv.innerHTML = '⚠️ Withdrawal rate should be between 1% and 10%';
                resultDiv.className = 'result error';
                resultDiv.style.display = 'block';
                return;
            }
            
            try {
                const response = await fetch('/api/fire/calculate', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ expenses, swr })
                });
                
                if (!response.ok) {
                    throw new Error('Calculation failed');
                }
                
                const result = await response.json();
                const fireNumber = result.fireNumber.toLocaleString();
                const yearsToSave = Math.ceil(fireNumber / (expenses * 0.5)); // Assuming 50% savings rate
                
                resultDiv.innerHTML = `
                    <div style='font-size: 1.5rem; margin-bottom: 10px;'>🎯 Your FIRE Number</div>
                    <div style='font-size: 2rem; font-weight: 700;'>€${fireNumber}</div>
                    <div style='font-size: 0.9rem; margin-top: 10px; opacity: 0.9;'>
                        At ${(swr * 100).toFixed(1)}% withdrawal rate • ~${yearsToSave} years to save
                    </div>
                `;
                resultDiv.className = 'result';
                resultDiv.style.display = 'block';
                
            } catch (error) {
                resultDiv.innerHTML = '❌ Error calculating. Please try again.';
                resultDiv.className = 'result error';
                resultDiv.style.display = 'block';
            }
        }
        
        // Allow Enter key to trigger calculation
        document.addEventListener('DOMContentLoaded', function() {
            const inputs = document.querySelectorAll('input');
            inputs.forEach(input => {
                input.addEventListener('keypress', function(e) {
                    if (e.key === 'Enter') {
                        calculate();
                    }
                });
            });
        });
    </script>
</body>
</html>
", "text/html"));

app.Run();

