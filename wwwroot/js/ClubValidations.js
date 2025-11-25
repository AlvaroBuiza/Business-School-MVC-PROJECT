document.addEventListener("DOMContentLoaded", () => {
    const form = document.querySelector('#ClubForm');
    if (!form) return;

   
    const fields = ['ClubName', 'DepartmentId'];

    
    const validators = {
        ClubName: v => {
            if (!v) return 'Club name is required';
            if (v.length < 3 || v.length > 50) return 'The club name must be between 3 and 50 characters';
            return '';
        },
        DepartmentId: v => {
            if (!v) return 'Department is required';
            const n = parseInt(v, 10);
            if (isNaN(n) || n <= 0) return 'You must select a valid department';
            return '';
        }
    };

    
    const showError = (field, message) => {
        const input = form.querySelector(`[name="${field}"]`);
        const feedback =
            form.querySelector(`div.invalid-feedback[data-valmsg-for="${field}"]`) ||
            form.querySelector(`span[data-valmsg-for="${field}"]`);
        if (!input || !feedback) return;

        if (message) {
            input.classList.add('is-invalid');
            input.classList.remove('is-valid');
            feedback.textContent = message;
        } else {
            input.classList.remove('is-invalid');
            input.classList.add('is-valid');
            feedback.textContent = '';
        }
    };

  
    const validateField = field => {
        const input = form.querySelector(`[name="${field}"]`);
        if (!input) return false;
        const val = (input.value ?? '').trim();
        const msg = validators[field](val);
        showError(field, msg);
        return !msg;
    };

   
    const validateForm = () => fields.map(validateField).every(Boolean);

   
    fields.forEach(f => {
        const el = form.querySelector(`[name="${f}"]`);
        if (!el) return;
        const handler = () => validateField(f);
        if (el.tagName.toLowerCase() === 'select') {
            el.addEventListener('change', handler);
            el.addEventListener('blur', handler);
        } else {
            el.addEventListener('input', handler);
            el.addEventListener('blur', handler);
        }
    });

   
    form.addEventListener('submit', e => {
        if (!validateForm()) e.preventDefault();
    });
});
