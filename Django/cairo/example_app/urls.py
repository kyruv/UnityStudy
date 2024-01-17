from django.urls import path

from . import views

urlpatterns = [
    path("example_app", views.index, name="index"),
    path("survey_one_data", views.survey_one_data, name="survey_one_data"),
    path("unity_post_game_end", views.unity_callback_game_end, name="unity_callback_game_end"),
    path("unity_post_s1_end", views.unity_callback_s1_end, name="unity_callback_s1_end"),
    path("unity_post_s2_end", views.unity_callback_s2_end, name="unity_callback_s2_end")
]