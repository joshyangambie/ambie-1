﻿using Windows.UI.Xaml;

namespace AmbientSounds.Converters
{
    /// <summary>
    /// Extensions for converting visiblity.
    /// </summary>
    public static class VisibilityConverter
    {
        /// <summary>
        /// Inverts the given bool to a visibility.
        /// </summary>
        public static Visibility InvertBool(this bool value)
        {
            return InvertVisibility(value ? Visibility.Visible : Visibility.Collapsed);
        }

        /// <summary>
        /// Inverts the given visibility.
        /// </summary>
        public static Visibility InvertVisibility(this Visibility value)
        {
            return value == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
