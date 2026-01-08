library(dplyr)
library(jsonlite)
library(tidyr)
library(ggplot2)


data <- read.csv("Sound_Data - Ark1.csv", sep = ",", quote = "\"")
View(data)

#Total VVIQ
data <- data %>%
  +     mutate(VVIQ_total = rowSums(select(., starts_with("VVIQ")), na.rm = TRUE))

#Participant ID change
data$session_id <- paste0("P", seq_len(nrow(data)))




#Bubble plot frequency 
ggplot(emo_sum, aes(x = song_id, y = emotion)) +
  geom_point(
    aes(size = n, color = mean_intensity),
    alpha = 0.9
  ) +
  shadowtext::geom_shadowtext(
    aes(label = n),
    colour = "white",
    bg.colour = "black",
    bg.r = 0.08,
    size = 4,
    fontface = "bold"
  ) +
  scale_size(range = c(6, 16)) +
  scale_color_gradient(
    low = "#deebf7",
    high = "#08306b"
  ) +
  guides(size = "none") +
  labs(
    x = "Song emotion",
    y = "Reported emotion",
    color = "Mean intensity",
    title = "Emotion reports by song type (frequency + intensity)"
  ) +
  theme_minimal(base_size = 13) +
  theme(
    axis.text.x  = element_text(size = 16, face = "bold"),
    axis.text.y  = element_text(size = 13),
    axis.title.x = element_text(size = 14),
    axis.title.y = element_text(size = 14),
    plot.title   = element_text(size = 18, face = "bold"),
    legend.title = element_text(size = 13),
    legend.text  = element_text(size = 12)
  )


#FIRST RESPONSE FIGURE
first_press <- press_events_long %>%
  group_by(session_id, song_id) %>%
  slice_min(time, n = 1) %>%
  ungroup()

ggplot(first_press, aes(x = song_id, fill = key)) +
  geom_bar(position = "fill") +
  scale_y_continuous(labels = scales::percent) +
  labs(
    x = "Song emotion",
    y = "Proportion of first responses",
    fill = "First response",
    title = "Imagery responses occur earlier during sad music"
  ) +
  theme_minimal(base_size = 13)




