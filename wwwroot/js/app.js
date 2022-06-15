const tBody = document.getElementById("table-body");
const getWh = () => {
    axios.get("https://localhost:7133/weatherforecast")
        .then(response => {
            const wheter = response.data;
            wheter.forEach(item => {
                const tr = document.createElement("tr");
                const tdDate = document.createElement("td");
                const tdTemp = document.createElement("td");
                const tdSummary = document.createElement("td");
                tdDate.innerHTML = item["date"];
                tdTemp.innerHTML = item["temperatureC"];
                tdSummary.innerHTML = item["summary"];
                tr.appendChild(tdDate);
                tr.appendChild(tdTemp);
                tr.appendChild(tdSummary);
                tBody.appendChild(tr);
            });
        })
        .catch(error => console.error(error));
};
getWh();
