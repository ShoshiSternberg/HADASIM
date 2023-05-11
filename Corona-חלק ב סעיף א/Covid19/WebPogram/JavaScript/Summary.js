//הצגת טבלה של כל החולים
function createGraph() {
    var path = 'https://localhost:44305/api/Patients/Get';
    //מיליוי מהמסד נתונים 
    axios.get(path).then(
        (response) => {
            console.log(response)
            var all_entitis = response.data;
            // Create a new Date object
            var currentDate = new Date();

            // Get the day of the month (from 1 to 31)
            var day = currentDate.getDate();
            var month = currentDate.getMonth() + 1;
            var year = currentDate.getFullYear();
            last_month = month - 1;
            var d, day;
            const arraySize = 30;
            const newArray = new Array(arraySize);
            for (var i = 0; i < arraySize; i++) {
                newArray[i] = 0;
            }
            // var date = new Date(e_date);
            for (var i = 0; i < all_entitis.length; i++) {
                pd = new Date(all_entitis[i].positve_date);
                rd = new Date(all_entitis[i].recovery_date);
                if (pd.getMonth() + 1 == last_month && pd.getFullYear() == year) {
                    if (rd.getMonth() != pd.getMonth())
                        ds = 31;
                    else
                        ds = rd.getDate();
                    for (var j = pd.getDate(); j <= ds; j++) {
                        newArray[j - 1]++;
                    }
                }
                else if (rd.getMonth() + 1 == last_month && rd.getFullYear() == year) {
                    for (var j = 0; j < rd.getDate(); j++)
                        newArry[j]++;
                }
            }
            points = Array(30);
            for (var i = 0; i < 30; i++) {
                points[i] = [i + 1, newArray[i]];
            }

            var canvas = document.createElement("canvas")
            
            document.getElementById("g").appendChild(canvas);
            ctx = canvas.getContext('2d');
            const data = {
                datasets: [
                    {
                        label: 'Sales',
                        data: points,
                        backgroundColor: 'rgba(75, 192, 192, 0.6)',
                        borderColor: 'rgba(75, 192, 192, 1)',
                        pointRadius: 5,
                        pointHoverRadius: 8,
                    },
                ],
            };

            const options = {
                responsive: true,
                scales: {
                    x: {
                        type: 'linear',
                        position: 'bottom',
                    },
                    y: {
                        type: 'linear',
                        position: 'left',
                    },
                },
            };

            c = new Chart(ctx, {
                type: 'line',
                data: data,
                options: options,
            });
        },
        (error) => {
            console.log(error);
        }
    );

}

path = 'https://localhost:44305/api/'
/*כמות החברים בקופת חולים שלא התחסנו*/
function check_p_notvaccinated() {

    axios.get(path + 'Entities/Get').then(
        (response) => {
            console.log(response);
            resEntities = response.data;

        },
        (error) => {
            console.log(error);
        }
    );

    axios.get(path + 'Vaccinated/Get').then(
        (respo) => {
            console.log(respo)
            var resVaccinated = respo.data;
             newArray = new Array(resVaccinated.length);
            for (var i = 0; i < resVaccinated.length; i++) {
                newArray[i] = resVaccinated[i].entity_id;              
            }
            vaccinatedSet = new Set(newArray);

            // Filter out the friends whose ID number is not in the vaccinated set
            const nonVaccinatedFriends = resEntities.filter(friend => !vaccinatedSet.has(friend.entity_id));

            // Return the count of non-vaccinated friends
            alert("כמות החברים שלא חוסנו עד כה: "+ nonVaccinatedFriends.length);
        },
        (error) => {
            console.log(error);
        }
            );

}
