from django.http import HttpResponse
from django.views.decorators.csrf import csrf_exempt
import json
from django.shortcuts import render
from example_app.models import FlappyBirdStudyResult


def index(request):
    print(request)
    return render(request, 'example_app/index.html')

# The below are called by Unity using POST messages in BackendLogger.cs

@csrf_exempt
def unity_callback_game_end(request):
    print("Unity game end callback")

    user_id = request.POST["user_id"]  
    attempt_number = int(request.POST["attempt_number"])
    game_progress = int(request.POST["columns_spanwed"])
    num_clicks = int(request.POST["num_clicks"])

    print(f"user_id: {user_id}, attempt: {attempt_number}, game_progress: {game_progress}, num_clicks: {num_clicks}")
    
    db_entry, _ = FlappyBirdStudyResult.objects.get_or_create(user_id=user_id)

    if db_entry.game_data is None:
        db_entry.game_data = {
            'game': [{
                'clicks': num_clicks,
                'progess': game_progress
            }]
        }
    else:
        existing_data = list(db_entry.game_data['game'])
        existing_data.append({
                'clicks': num_clicks,
                'progess': game_progress
            })
        db_entry.game_data = {
            'game': existing_data
        }
    
    
    db_entry.save()

    return HttpResponse("Success")

@csrf_exempt
def pre_game_survey_data(request):
    print("pre game survey callback")
    json_data = json.loads(request.body.decode('utf-8'))
    user_id = json_data.get('user_id')

    db_entry, _ = FlappyBirdStudyResult.objects.get_or_create(user_id=user_id)
    db_entry.s1_name = json_data.get('name')
    db_entry.prolific_id = json_data.get('prolific_id')
    db_entry.s1_color = json_data.get('color')
    db_entry.save()

    return HttpResponse("Success")


@csrf_exempt
def mid_game_survey_data(request):
    print("mid game survey callback")
    json_data = json.loads(request.body.decode('utf-8'))
    user_id = json_data.get('user_id')

    db_entry, did_create = FlappyBirdStudyResult.objects.get_or_create(user_id=user_id)

    if did_create:
        return HttpResponse("Database Entry didn't exist even though it should have")
    
    db_entry.s2_opinion = json_data.get('opinion')
    db_entry.save()

    return HttpResponse("Success")

@csrf_exempt
def post_game_survey_data(request):
    print("post game survey callback")
    json_data = json.loads(request.body.decode('utf-8'))
    user_id = json_data.get('user_id')

    db_entry, did_create = FlappyBirdStudyResult.objects.get_or_create(user_id=user_id)

    if did_create:
        return HttpResponse("Database Entry didn't exist even though it should have")
    
    db_entry.s3_preference = json_data.get('preference')
    db_entry.save()

    return HttpResponse("Success")

