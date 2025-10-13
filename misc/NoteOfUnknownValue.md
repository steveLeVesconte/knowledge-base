#curl #eventgrid
 
 
 http://localhost:7236/api/EventPublisherFunction



curl -X POST <function-endpoint-url> -H "Content-Type: application/json" -d '{"data":"sample"}'

curl -X POST http://localhost:7236/api/EventPublisherFunction -H "Content-Type: application/json" -d '{"data":"sample"}'


az eventgrid event-subscription show \
  --name <subscription name> \
  --source-resource-id "/subscriptions/<sub-id>/resourceGroups/<rg>/providers/Microsoft.EventGrid/topics/<topic>"


az-204-lab-subscription

az eventgrid event-subscription show \
  --name az-204-lab-subscription \
  --source-resource-id "/subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourceGroups/az-204-eventgrid-lab-rg/providers/Microsoft.EventGrid/topics/topic-eventgrid-demo"



 http://localhost:7198/api/EventPublisherFunction

# Example using PowerShell's Invoke-RestMethod
Invoke-RestMethod -Uri "http://localhost:7198/api/EventPublisherFunction" -Method POST -ContentType "application/json" -Body '{"data":"sample"}'


 http://localhost:7052/api/EventPublisherFunction


Invoke-RestMethod -Uri "http://localhost:7052/api/EventPublisherFunction" -Method POST -ContentType "application/json" -Body '{"data":"sample"}'

xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx


 http://localhost:7224/api/HelloFunction


Kristin, thaleia, me, Gabrielle, Nicholas, Tanya

