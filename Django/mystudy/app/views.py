from django.http import HttpResponse
from django.views.decorators.csrf import csrf_exempt
import json
from django.shortcuts import render
from app.db_update import save_game_data, save_s1_data, save_s2_data


def index(request):
    
    return render(request, 'index.html')

# The below are called by Unity using POST messages in BackendLogger.cs

@csrf_exempt
def unity_callback_game_end(request):
    user_id = request.POST["user_id"]
    
    game_score = float(request.POST["game_score"])
    game_time = float(request.POST["game_time"])
    save_game_data(user_id, game_score, game_time)

    return HttpResponse("Success")

@csrf_exempt
def unity_callback_s1_end(request):
    user_id = request.POST["user_id"]

    s1_q1 = request.POST["s1_q1"]
    s1_q2 = request.POST["s1_q2"]
    save_s1_data(user_id, s1_q1, s1_q2)

    return HttpResponse("Success")

@csrf_exempt
def unity_callback_s2_end(request):
    user_id = request.POST["user_id"]

    s2_q1 = request.POST["s2_q1"]
    save_s2_data(user_id, s2_q1)

    return HttpResponse("Success")

