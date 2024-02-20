function post_click_survey(user_id) {

    // Survey JSON
    var surveyJSON = {
        title: "Thanks for completing the first round of the game. Complete this survey to continue to the final .",
        pages: [
            {
                questions: [
                    { type: "text", name: "opinion", title: "Did you like the game?" },
                ]
            }
        ]
    };

    var canvas = document.getElementById("unity-canvas");

    if (canvas) {
        disable_unity();

        // Initialize Survey
        var survey = new Survey.Model(surveyJSON);

        // Access Survey Responses
        survey.onComplete.add(function (result) {
            enable_unity();
            var surveyContainer = document.getElementById("survey");
            surveyContainer.innerHTML = "";
            var newDataCopy = Object.assign({}, result.data);
            // Add user_id to the new dictionary
            newDataCopy["user_id"] = user_id;
            console.log(newDataCopy);

            fetch(midGameSurveyUrl, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(newDataCopy),
            })
        });

        // Run the Survey
        survey.render("survey");
        survey.start();
    }

}

