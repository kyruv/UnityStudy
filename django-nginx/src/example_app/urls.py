from django.urls import path

from . import views

urlpatterns = [
    path("example_app", views.index, name="index"),
    path("unity_flappy_bird_player_died", views.unity_callback_game_end, name="unity_callback_game_end"),
    path("pre_game_survey_data", views.pre_game_survey_data, name="pre_game_survey_data"),
    path("mid_game_survey_data", views.mid_game_survey_data, name="mid_game_survey_data"),
    path("post_game_survey_data", views.post_game_survey_data, name="post_game_survey_data"),
]