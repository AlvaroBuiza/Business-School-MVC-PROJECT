document.addEventListener("DOMContentLoaded", () => {
    const form = document.querySelector('#DepartmentForm');
    if (!form) return;

    const fields = ['DepartamentName', 'Phone_Number', 'Email', 'Office_Location'];

    const validators = {
        DepartamentName: v => {
            if (!v) return 'Department name is required';
            if (v.length < 6 || v.length > 50) return 'Name must be between 6 and 50 characters';
            return '';
        },
        Phone_Number: v => {
            if (!v) return 'Phone number is required';
            if (!/^\d{9}$/.test(v)) return 'Phone number must contain exactly 9 digits';
            return '';
        },
        Email: v => {
            if (!v) return 'Email is required';
            const regex = /^[^@\s]+@[^@\s]+\.[^@\s]+$/;
            if (!regex.test(v)) return 'Must be a valid email format';
            return '';
        },
        Office_Location: v => {
            if (!v) return 'Office location is required';
            if (v.length < 6 || v.length > 50) return 'Office location must be between 6 and 50 characters';
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
        el.addEventListener('input', handler);
        el.addEventListener('blur', handler);
    });

    form.addEventListener('submit', e => {
        if (!validateForm()) e.preventDefault();
    });
});
