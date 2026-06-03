window.upskillTheme = {
    storageKey: 'upskill-theme',
    validThemes: ['light', 'dark'],

    getStoredTheme: function () {
        const storedTheme = localStorage.getItem(this.storageKey);
        return this.validThemes.includes(storedTheme) ? storedTheme : 'light';
    },

    applyTheme: function (theme) {
        const nextTheme = this.validThemes.includes(theme) ? theme : 'light';
        document.documentElement.setAttribute('data-theme', nextTheme);
        localStorage.setItem(this.storageKey, nextTheme);
        return nextTheme;
    },

    toggleTheme: function () {
        const currentTheme = document.documentElement.getAttribute('data-theme') || this.getStoredTheme();
        return this.applyTheme(currentTheme === 'dark' ? 'light' : 'dark');
    }
};

(function () {
    const storedTheme = window.upskillTheme.getStoredTheme();
    document.documentElement.setAttribute('data-theme', storedTheme);
})();
